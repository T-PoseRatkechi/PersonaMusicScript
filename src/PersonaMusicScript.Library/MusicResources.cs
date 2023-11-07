using System.Text.Json;

namespace PersonaMusicScript.Library;

public class MusicResources
{
    public static readonly Dictionary<string, GameProperties> Games = new()
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
        var songsFile = Path.Join(this.ResourcesDir, "songs.data");
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