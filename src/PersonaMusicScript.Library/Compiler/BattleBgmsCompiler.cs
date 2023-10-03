namespace PersonaMusicScript.Library.Compiler;

public class BattleBgmsCompiler : IMusicCompiler
{
    public void Compile(Music music, List<string> patch, string outputDir)
    {
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

        var battleBgmsVar = $"var battleBgms({battleBgmsBytes.Count}) = bytes({Convert.ToHexString(battleBgmsBytes.ToArray())})";
        patch.Insert(0, battleBgmsVar);
    }
}
