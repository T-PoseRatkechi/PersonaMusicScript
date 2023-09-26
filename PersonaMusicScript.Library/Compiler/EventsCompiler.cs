using LibellusLibrary.Event.Types.Frame;
using LibellusLibrary.Event.Types;
using LibellusLibrary.Event;
using static LibellusLibrary.Event.Types.Frame.PmdFrameFactory;

namespace PersonaMusicScript.Library.Compiler;

public class EventsCompiler : IMusicCompiler
{
    public void Compile(Music music, string outputDir)
    {
        foreach (var eventFrame in music.Events)
        {
            var eventFile = eventFrame.Key;
            var originalFile = Path.Join(music.Resources.ResourcesDir, "original", eventFile);
            var outputFile = Path.Join(outputDir, eventFile);
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile)!);

            var reader = new PmdReader();
            var pmd = reader.ReadPmd(originalFile).Result;

            foreach (var entry in pmd.PmdDataTypes)
            {
                if (entry is PmdData_FrameTable frameTable)
                {
                    var duplicateEntries = new List<PmdTargetType>();
                    foreach (var frameBgm in eventFrame.Value.FrameBgms)
                    {
                        var frameBgmData = new byte[52];
                        var bgmBytes = BitConverter.GetBytes(frameBgm.Bgm);

                        // BGM id is at offset 14 in data.
                        frameBgmData[14] = bgmBytes[0];
                        frameBgmData[15] = bgmBytes[1];

                        var pmdEntry = new PmdTarget_Unknown()
                        {
                            StartFrame = frameBgm.StartFrame,
                            TargetType = PmdTargetTypeID.BGM,
                            Data = frameBgmData,
                        };

                        // Remove any existing BGM frame entry at same start frame.
                        duplicateEntries.AddRange(frameTable.Frames.Where(x => x.StartFrame == frameBgm.StartFrame && x.TargetType == PmdTargetTypeID.BGM));
                        frameTable.Frames.Add(pmdEntry);
                    }

                    foreach (var duplicate in duplicateEntries)
                    {
                        frameTable.Frames.Remove(duplicate);
                    }
                }
            }

            pmd.SavePmd(outputFile);
        }
    }
}
