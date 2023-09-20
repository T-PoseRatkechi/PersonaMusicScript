using System.Text.Json;

namespace PersonaMusicScript.Library;

internal class MusicResources
{
    private readonly string resourcesDir;

    public MusicResources(string game)
    {
        this.resourcesDir = Directory.CreateDirectory(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "resources", game)).FullName;

        this.Songs = this.GetSongs();
        this.Collections = this.GetCollections();
    }

    public Dictionary<string, int> Songs { get; set; }

    public Dictionary<string, int[]> Collections { get; }

    private Dictionary<string, int> GetSongs()
    {
        var songsFile = Path.Join(this.resourcesDir, "songs.json");
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
        var collectionsDir = Directory.CreateDirectory(Path.Join(this.resourcesDir, "collections")).FullName;
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
}
