using Persona.Music.Types.Common;
using PersonaModdingMetadata.Shared.Games;
using PersonaModdingMetadata.Shared.Serializers;

namespace PersonaMusicScript.Types;

public class MusicResources
{
    public static readonly Dictionary<Game, GameProperties> Games = new()
    {
        [Game.P4G_PC] = new()
        {
            TotalEncounters = 944,
            TotalFloors = 300,
            GetOutputPath = (id) => $"FEmulator/AWB/snd00_bgm.awb/{id}.hca",
            Encoder = "HCA",
        },

        [Game.P3P_PC] = new()
        {
            TotalEncounters = 1024,
            TotalFloors = 264,
            GetOutputPath = (id) => $"P5REssentials/CPK/BGME/data/sound/bgm/{id}.adx",
            Encoder = "ADX",
        },

        [Game.P5R_PC] = new()
        {
            TotalEncounters = 1000,
            GetOutputPath = (id) =>
            {
                if (id >= 10000)
                {
                    return $"FEmulator/AWB/BGM_42.AWB/{id - 10000}.adx";
                }

                return $"FEmulator/AWB/BGM.AWB/{id}.adx";
            },
            Encoder = "ADX (Persona 5 Royal PC)",
        },
    };

    public MusicResources(Game game, string? resourcesDir = null)
    {
        if (string.IsNullOrEmpty(resourcesDir))
        {
            this.ResourcesDir = Directory.CreateDirectory(game.GameFolder(AppDomain.CurrentDomain.BaseDirectory)).FullName;
        }
        else
        {
            this.ResourcesDir = Directory.CreateDirectory(game.GameFolder(resourcesDir)).FullName;
        }

        this.Constants = Games[game];
        this.Songs = this.GetSongs();
        this.Collections = this.GetCollections();
    }

    public string ResourcesDir { get; }

    public Dictionary<string, int> Songs { get; }

    public Dictionary<string, int[]> Collections { get; }

    public GameProperties Constants { get; }

    private Dictionary<string, int> GetSongs()
    {
        var deserializer = new YamlDotNet.Serialization.Deserializer();
        var musicFile = Path.Join(this.ResourcesDir, "music.yaml");

        if (File.Exists(musicFile))
        {
            var music = deserializer.Deserialize<GameMusic>(File.ReadAllText(musicFile));
            var songCueIdData = music.Songs.ToDictionary(x => x.Name, y => y.CueId);
            return new(songCueIdData, StringComparer.OrdinalIgnoreCase);
        }

        return new();
    }

    private Dictionary<string, int[]> GetCollections()
    {
        var collectionsDir = Path.Join(this.ResourcesDir, "collections");
        var collections = new Dictionary<string, int[]>(StringComparer.OrdinalIgnoreCase);

        if (Directory.Exists(collectionsDir))
        {
            foreach (var file in Directory.EnumerateFiles(collectionsDir, "*.enc", SearchOption.AllDirectories))
            {
                var collection = CollectionSerializer.DeserializeFile(file);
                collections.Add(Path.GetFileNameWithoutExtension(file), collection);
            }
        }

        // Add normal battles collection
        // by inversing the Special Battles collection.
        var normalBattles = new List<int>();
        if (collections.TryGetValue("Special Battles", out var specialBattles))
        {
            for (int i = 0; i < this.Constants.TotalEncounters; i++)
            {
                if (!specialBattles.Contains(i))
                {
                    normalBattles.Add(i);
                }
            }
        }

        collections.Add("Normal Battles", normalBattles.ToArray());
        return collections;
    }
}

public class GameProperties
{
    public int TotalEncounters { get; init; }

    public int TotalFloors { get; init; }

    public int IsBigEndian { get; init; }

    /// <summary>
    /// TODO: Currently assumes the ID is the AWB index, but music scripts
    /// use Cue ID for game songs in P4G and P5R. Need to map Cue ID to AWB index.
    /// </summary>
    public required Func<int, string> GetOutputPath { get; init; }

    public required string Encoder { get; init; }
}