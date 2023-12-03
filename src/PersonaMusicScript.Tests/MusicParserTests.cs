using PersonaModdingMetadata.Shared.Games;
using PersonaMusicScript.Library;

namespace PersonaMusicScript.Tests;

public class MusicParserTests
{
    [Fact]
    void MusicParser_EncounterBlock_EncounterId()
    {
        var script =
        "encounter[1]:\n" +
        "music = 100\n" +
        "end\n";

        var parser = new MusicParser(Game.P4G_PC);
        var exception = Record.Exception(() => parser.Parse(script));
        Assert.Null(exception);
    }

    [Fact]
    void MusicParser_EncounterBlock_Collection()
    {
        var script =
        "encounter[\"The Reaper\"]:\n" +
        "music = 100\n" +
        "end\n";

        var parser = new MusicParser(Game.P4G_PC);
        var exception = Record.Exception(() => parser.Parse(script));
        Assert.Null(exception);
    }
}
