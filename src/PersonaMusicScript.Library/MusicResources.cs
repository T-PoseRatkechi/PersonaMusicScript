using PersonaMusicScript.Library.Models;
using System.Text.Json;

namespace PersonaMusicScript.Library;

public class MusicResources
{
    private static readonly Dictionary<string, GameConstants> Games = new()
    {
        [Game.P4G_PC] = new GameConstants(24, 944, "HCA", (id) => $"FEmulator/AWB/snd00_bgm.awb/{id}.hca", new Song(77), new Song(30), new Song(30), new Song(35)),
        [Game.P3P_PC] = new GameConstants(28, 1024, "ADX", (id) => $"P5REssentials/CPK/BGME/data/sound/bgm/{id}.adx", new Song(26), new Song(26), new Song(26), new Song(60)),
        [Game.P5R_PC] = new GameConstants(44, 1000, "ADX (Persona 5 Royal PC)", (id) => $"FEmulator/AWB/BGM.AWB/{id}.adx", new Song(118), new Song(6), new Song(118), new Song(1), true),
    };

    private static readonly Dictionary<string, string> gamePatchFiles = new()
    {
        [Game.P4G_PC] = "BGME_P4G64_Release.expatch",
        [Game.P3P_PC] = "BGME_P3P_Release.expatch",
        [Game.P5R_PC] = "BGME_P5R_Release.expatch",
    };

    public MusicResources(string game, string? resourcesDir = null)
    {
        if (string.IsNullOrEmpty(resourcesDir))
        {
            this.ResourcesDir = Directory.CreateDirectory(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "resources", game)).FullName;
        }
        else
        {
            this.ResourcesDir = Directory.CreateDirectory(Path.Join(resourcesDir, game)).FullName;
        }

        this.Songs = this.GetSongs();
        this.Collections = this.GetCollections();
        this.Constants = Games[game];
        this.PatchFile = Path.Join(this.ResourcesDir, gamePatchFiles[game]);
        this.TvFloorsMusic = this.GetTvFloorsMusic();
        this.DefaultEncounterMusic = this.GetEncounterMusic();
    }

    public string ResourcesDir { get; }

    public string PatchFile { get; }

    public Dictionary<string, int> Songs { get; }

    public Dictionary<string, int[]> Collections { get; }

    public GameConstants Constants { get; }

    public List<ushort> TvFloorsMusic { get; set; }

    public ushort[] DefaultEncounterMusic { get; set; }

    private List<ushort> GetTvFloorsMusic()
    {
        var music = new List<ushort>();
        var musicFile = Path.Join(this.ResourcesDir, "tv.music");
        if (File.Exists(musicFile))
        {
            using var reader = new BinaryReader(File.OpenRead(musicFile));
            var numEntries = reader.ReadInt32();
            for (int i = 0; i < numEntries; i++)
            {
                music.Add(reader.ReadUInt16());
            }
        }

        return music;
    }

    private Dictionary<string, int> GetSongs()
    {
        var songsFile = Path.Join(this.ResourcesDir, "songs.json");
        if (File.Exists(songsFile))
        {
            var loadedSongs = JsonSerializer.Deserialize<Dictionary<string, int>>(File.ReadAllText(songsFile))
                ?? throw new Exception();

            return new(loadedSongs, StringComparer.OrdinalIgnoreCase);
        }

        return new();
    }

    private Dictionary<string, int[]> GetCollections()
    {
        var collectionsDir = Directory.CreateDirectory(Path.Join(this.ResourcesDir, "collections")).FullName;
        var collections = new Dictionary<string, int[]>(StringComparer.OrdinalIgnoreCase);

        if (Directory.Exists(collectionsDir))
        {
            foreach (var file in Directory.EnumerateFiles(collectionsDir, "*.enc", SearchOption.AllDirectories))
            {
                var collectionName = Path.GetFileNameWithoutExtension(file);
                var ids = new List<int>();
                foreach (var line in File.ReadLines(file))
                {
                    if (int.TryParse(line, out var id))
                    {
                        ids.Add(id);
                    }
                }

                if (ids.Count > 0)
                {
                    collections.Add(collectionName, ids.ToArray());
                }
            }
        }

        return collections;
    }

    private ushort[] GetEncounterMusic()
    {
        var encounterMusic = new List<ushort>();
        var encountFile = Path.Join(this.ResourcesDir, "encount.music");
        if (File.Exists(encountFile))
        {
            using var reader = new BinaryReader(File.OpenRead(encountFile));

            var numEntires = reader.ReadUInt32();
            for (int i = 0; i < numEntires; i++)
            {
                encounterMusic.Add(reader.ReadUInt16());
            }
        }

        return encounterMusic.ToArray();
    }
}

public class GameConstants
{
    public GameConstants(
        int encounterSize,
        int totalEncounters,
        string encoder,
        Func<int, string> getOutputPath,
        IMusic defaultNormalMusic,
        IMusic defaultAdvantageMusic,
        IMusic defaultDisadvantageMusic,
        IMusic defaultVictoryMusic,
        bool isBigEndian = false)
    {
        this.EncounterEntrySize = encounterSize;
        this.TotalEncounters = totalEncounters;
        this.Encoder = encoder;
        this.GetOutputPath = getOutputPath;
        this.BigEndian = isBigEndian;
        this.DefaultNormalMusic = defaultNormalMusic;
        this.DefaultAdvantageMusic = defaultAdvantageMusic;
        this.DefaultDisadvantageMusic = defaultDisadvantageMusic;
        this.DefaultVictoryMusic = defaultVictoryMusic;
    }

    public bool BigEndian { get; }

    public int TotalEncounters { get; }

    public int EncounterEntrySize { get; }

    public string Encoder { get; }

    public Func<int, string> GetOutputPath { get; }

    public IMusic DefaultNormalMusic { get; }

    public IMusic DefaultAdvantageMusic { get; }

    public IMusic DefaultDisadvantageMusic { get; }

    public IMusic DefaultVictoryMusic { get; }
}
