﻿namespace PersonaMusicScript.Library.Compiler;

public class EncountersCompiler : IMusicCompiler
{
    private static readonly Dictionary<string, string> gamePatchFiles = new()
    {
        [Game.P4G_PC] = "BGME_P4G64_Release.expatch",
        [Game.P3P_PC] = "BGME_P3P_Release.expatch",
        [Game.P5R_PC] = "BGME_P5R_Release.expatch",
    };

    public void Compile(Music music, string outputDir)
    {
        var encountFile = Path.Join(music.Resources.ResourcesDir, "ENCOUNT.TBL");
        if (!File.Exists(encountFile))
        {
            throw new FileNotFoundException("Original ENCOUNT.TBL file missing.", encountFile);
        }

        var outputEncountFile = Path.Join(outputDir, "ENCOUNT.TBL");
        File.Copy(encountFile, outputEncountFile, true);

        var encountEntrySize = music.Resources.Constants.EncounterEntrySize;
        using var writer = new BinaryWriter(File.OpenWrite(outputEncountFile));
        foreach (var encounter in music.Encounters)
        {
            writer.Seek(encounter.Index * encountEntrySize + 4, SeekOrigin.Begin);

            // Skip flags.
            writer.Seek(4, SeekOrigin.Current);

            // Write Field04.
            writer.Write((byte)encounter.Field04_1);
            writer.Write((byte)encounter.Field04_2);

            // Write Field06.
            writer.Write(encounter.Field06);

            // Move to music.
            writer.Seek(14, SeekOrigin.Current);

            // Write music.
            writer.Write(encounter.Music);
        }

        BuildPatch(music, outputDir);
    }

    private static void BuildPatch(Music music, string outputDir)
    {
        var patchFile = Path.Join(music.Resources.ResourcesDir, gamePatchFiles[music.Game]);
        var lines = File.ReadLines(patchFile).ToList();

        // Create random songs data var.
        var randomSongsBytes = new List<byte>();
        foreach (var randomSong in music.Source.RandomSongs)
        {
            var minBytes = BitConverter.GetBytes((ushort)randomSong.MinSongId);
            var maxBytes = BitConverter.GetBytes((ushort)randomSong.MaxSongId);
            randomSongsBytes.AddRange(minBytes);
            randomSongsBytes.AddRange(maxBytes);
        }

        var randomSongsString = BitConverter.ToString(randomSongsBytes.ToArray()).Replace('-', ' ');
        var randomSongsIndex = lines.FindIndex(x => x.StartsWith("var randomSongs"));
        if (randomSongsIndex == -1)
        {
            throw new Exception("var randomSongs not found in patch.");
        }

        lines[randomSongsIndex] = $"var randomSongs({randomSongsBytes.Count}) = bytes({randomSongsString})";

        // Create battle music data var.
        var battleBgmsBytes = new List<byte>();
        foreach (var battleBgm in music.Source.BattleBgms)
        {
            ushort config = 0;
            var normalBytes = new byte[] { 0x00, 0x00 };
            if (battleBgm.NormalBGM != null)
            {
                config = (byte)(config | (byte)battleBgm.NormalBGM.Type);
                normalBytes = BitConverter.GetBytes((ushort)battleBgm.NormalBGM.Id);
            }

            config = (byte)(config << 2);

            var advantageBytes = new byte[] { 0x00, 0x00 }; ;
            if (battleBgm.AdvantageBGM != null)
            {
                config = (byte)(config | (byte)battleBgm.AdvantageBGM.Type);
                advantageBytes = BitConverter.GetBytes((ushort)battleBgm.AdvantageBGM.Id);
            }

            config = (byte)(config << 2);

            var disadvantageBytes = new byte[] { 0x00, 0x00 }; ;
            if (battleBgm.DisadvantageBGM != null)
            {
                config = (byte)(config | (byte)battleBgm.DisadvantageBGM.Type);
                disadvantageBytes = BitConverter.GetBytes((ushort)battleBgm.DisadvantageBGM.Id);
            }

            battleBgmsBytes.AddRange(BitConverter.GetBytes(config));
            battleBgmsBytes.AddRange(normalBytes);
            battleBgmsBytes.AddRange(advantageBytes);
            battleBgmsBytes.AddRange(disadvantageBytes);
        }

        if (battleBgmsBytes.Count == 0)
        {
            battleBgmsBytes.Add(0x00);
        }

        var battleBgmsString = BitConverter.ToString(battleBgmsBytes.ToArray()).Replace('-', ' ');
        var battleBgmsIndex = lines.FindIndex(x => x.StartsWith("var battleBgms"));
        if (battleBgmsIndex == -1)
        {
            throw new Exception("var battleBgms not found in patch.");
        }

        lines[battleBgmsIndex] = $"var battleBgms({battleBgmsBytes.Count}) = bytes({battleBgmsString})";

        var outputFile = Path.Join(outputDir, Path.GetFileName(patchFile));
        File.WriteAllLines(outputFile, lines);
    }
}