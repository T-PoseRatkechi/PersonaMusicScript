using PersonaMusicScript.Types;
using Phos.MusicManager.Library.Projects;
using Phos.MusicManager.Library.Serializers;

namespace PersonaMusicScript.Library.Presets;

internal class PresetBuilder
{
    private readonly MusicResources resources;

    public PresetBuilder(MusicResources resources)
    {
        this.resources = resources;
    }

    public void Create(MusicSource source, string outputFile)
    {
        var musicUse = new MusicUse(source);
        var tracks = musicUse.Select(x => new PresetAudioTrack()
        {
            Name = $"BGM ID: {x.Key}",
            Category = "BGME Framework",
            Tags = x.Value.ToArray(),
            OutputPath = this.resources.Constants.GetOutputPath(x.Key),
            Encoder = this.resources.Constants.Encoder,
        }).ToArray();

        var name = Path.GetFileNameWithoutExtension(outputFile);
        var preset = new ProjectPreset()
        {
            Name = name,
            DefaultTracks = tracks,
        };

        ProtobufSerializer.Serialize(outputFile, preset);
    }
}
