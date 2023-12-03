using PersonaModdingMetadata.Shared.Games;
using PersonaMusicScript.Types;

namespace PersonaMusicScript.Tests;

public class MusicResourcesTest
{
    [Fact]
    void MusicResources_Collections_NormalBattlesExist()
    {
        foreach (var game in Enum.GetValues<Game>())
        {
            var resources = new MusicResources(game);
            var normalBattles = resources.Collections["Normal Battles"];
            Assert.True(normalBattles.Length > 0, $"{game}: Empty normal battles.");
        }
    }
}
