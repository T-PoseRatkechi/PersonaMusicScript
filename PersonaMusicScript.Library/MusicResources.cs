﻿using System.Text.Json;

namespace PersonaMusicScript.Library;

public class MusicResources
{
    private static readonly Dictionary<string, GameConstants> Games = new()
    {
        ["Persona 4 Golden PC x64"] = new GameConstants(24, 944, "HCA", (id) => $"FEmulator/AWB/snd00_bgm.awb/{id}.hca"),
        ["Persona 3 Portable PC"] = new GameConstants(28, 1024, "ADX", (id) => $"P5REssentials/CPK/BGME/data/sound/bgm/{id}.adx"),
        ["Persona 5 Royal PC"] = new GameConstants(44, 1000, "ADX (Persona 5 Royal PC)",(id) => $"FEmulator/AWB/BGM.AWB/{id}.adx", true),
    };

    public MusicResources(string game)
    {
        this.ResourcesDir = Directory.CreateDirectory(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "resources", game)).FullName;

        this.Songs = this.GetSongs();
        this.Collections = this.GetCollections();
        this.Constants = Games[game];
    }

    public string ResourcesDir { get; }

    public Dictionary<string, int> Songs { get; }

    public Dictionary<string, int[]> Collections { get; }

    public GameConstants Constants { get; }

    private Dictionary<string, int> GetSongs()
    {
        var songsFile = Path.Join(this.ResourcesDir, "songs.json");
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

        return collections;
    }
}

public class GameConstants
{
    public GameConstants(
        int encounterSize,
        int totalEncounters,
        string encoder,
        Func<int, string> getOutputPath,
        bool isBigEndian = false)
    {
        this.EncounterEntrySize = encounterSize;
        this.TotalEncounters = totalEncounters;
        this.Encoder = encoder;
        this.GetOutputPath = getOutputPath;
        this.BigEndian = isBigEndian;
    }

    public bool BigEndian { get; }

    public int TotalEncounters { get; }

    public int EncounterEntrySize { get; }

    public string Encoder { get; }

    public Func<int, string> GetOutputPath { get; }
}