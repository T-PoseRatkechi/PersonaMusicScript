using PersonaMusicScript.Library.Models;
using System.Text;

namespace PersonaMusicScript.Library.Compiler;

public class EncounterMusicCompiler : IMusicCompiler
{
    public void Compile(Music music, List<string> patch, string outputDir)
    {
        var patchEncounters = new List<EncounterEntry>();

        // Generate full list of encounters.
        for (int encounterId = 0; encounterId < music.Resources.DefaultEncounterMusic.Length; encounterId++)
        {
            // Add entry generated from script.
            if (music.Encounters.TryGetValue(encounterId, out var encounter))
            {
                patchEncounters.Add(encounter);
            }

            // Add new entry with default music.
            else
            {
                patchEncounters.Add(new(encounterId)
                {
                    Music = music.Resources.DefaultEncounterMusic[encounterId],
                    Field04_2 = MusicType.Song,
                    Field06 = (ushort)music.Resources.Constants.DefaultVictoryMusic.Id
                });
            }
        }

        var dataString = new StringBuilder();
        foreach (var encounter in patchEncounters)
        {
            dataString.Append(Convert.ToHexString(new byte[] { (byte)encounter.Field04_1, (byte)encounter.Field04_2 }));
            dataString.Append(Convert.ToHexString(BitConverter.GetBytes(encounter.Field06)));
            dataString.Append(Convert.ToHexString(BitConverter.GetBytes(encounter.Music)));
            dataString.Append("0000"); // Padding.
        }

        var varDeclaration = $"var encounterMusic({dataString.Length / 2}) = bytes({dataString})";
        patch.Insert(0, varDeclaration);
    }
}
