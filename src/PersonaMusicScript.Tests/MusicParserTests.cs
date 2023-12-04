using PersonaModdingMetadata.Shared.Games;
using PersonaMusicScript.Library;

namespace PersonaMusicScript.Tests;

public class MusicParserTests
{
    [Fact]
    public void MusicParser_EncounterBlock_EncounterId()
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
    public void MusicParser_EncounterBlock_Collection()
    {
        var script =
        "encounter[\"The Reaper\"]:\n" +
        "music = 100\n" +
        "end\n";

        var parser = new MusicParser(Game.P4G_PC);
        var exception = Record.Exception(() => parser.Parse(script));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("const set = battle_victory_set(1)", false)]
    [InlineData("const set = battle_victory_set(1, 2)", true)]
    [InlineData("const set = battle_victory_set(1, 2, 3)", false)]
    public void MusicParser_BattleVictorySet_Compiles(string script, bool compiles)
    {
        var parser = new MusicParser(Game.P4G_PC);
        bool actual = false;

        try
        {
            parser.Parse(script);
            actual = true;
            Assert.True(actual == compiles);

        }
        catch (Exception ex)
        {
            Assert.True(actual == compiles, ex.Message);
        }
    }

    [Theory]
    [InlineData("const randomMusic = random_music(1)", false)]
    [InlineData(
        "const array = [1, 2, random_song(1, 5)]" +
        "const randomMusic = random_music(array)",
        true)]
    public void MusicParser_RandomMusic_Compiles(string script, bool compiles)
    {
        var parser = new MusicParser(Game.P4G_PC);
        bool actual = false;

        try
        {
            parser.Parse(script);
            actual = true;
            Assert.True(actual == compiles);

        }
        catch (Exception ex)
        {
            Assert.True(actual == compiles, ex.Message);
        }
    }
}
