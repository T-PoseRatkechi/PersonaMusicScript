using PersonaMusicScript.Library.Models;
using Phos.MusicManager.Library.Projects;
using Phos.MusicManager.Library.Serializers;

namespace PersonaMusicScript.Library.Compiler;

internal static class MusicPreset
{
    public static void Create(Music music, string outputFile)
    {
        Dictionary<int, SongUse> songsUsed = new();

        // Add music used by constants.
        foreach (var constant in music.Source.Constants)
        {
            if (constant.Value is Song song)
            {
                AddSong(songsUsed, song, constant.Key);
            }
            else if (constant.Value is RandomSong randomSong)
            {
                AddRandomSong(songsUsed, randomSong, constant.Key);
            }
            else if (constant.Value is BattleBgm battleBgm)
            {
                AddBattleBgm(songsUsed, battleBgm, constant.Key);
            }
        }

        // Add songs used by encounters.
        foreach (var songId in music.Encounters.Where(x => x.Field04_1 == MusicType.Song).Select(x => x.Music).Distinct())
        {
            songsUsed.TryAdd(songId, new SongUse(songId));
            songsUsed[songId].UsedBy.Add($"Battle BGM");
        }

        foreach (var songId in music.Encounters.Where(x => x.Field04_2 == MusicType.Song).Select(x => x.Field06).Distinct())
        {
            songsUsed.TryAdd(songId, new SongUse(songId));
            songsUsed[songId].UsedBy.Add($"Victory BGM");
        }

        // Add remaining music.
        foreach (var randomSong in music.Source.RandomSongs)
        {
            AddRandomSong(songsUsed, randomSong, $"random_song({randomSong.MinSongId}, {randomSong.MaxSongId})");
        }

        foreach (var battleBgm in music.Source.BattleBgms)
        {
            AddBattleBgm(songsUsed, battleBgm, "battle_bgm");
        }

        var tracks = songsUsed.Select(x => new PresetAudioTrack()
        {
            Name = $"Song ID: {x.Key}",
            Category = "Uncategorized",
            Tags = x.Value.UsedBy.ToArray(),
            OutputPath = music.Resources.Constants.GetOutputPath(x.Key),
            Encoder = music.Resources.Constants.Encoder,
        }).ToArray();

        var name = Path.GetFileNameWithoutExtension(outputFile);
        var preset = new ProjectPreset()
        {
            Name = name,
            DefaultTracks = tracks,
        };

        ProtobufSerializer.Serialize(outputFile, preset);
    }

    private static void AddSong(Dictionary<int, SongUse> songsUsed, Song song, string name)
    {
        songsUsed.TryAdd(song.Id, new(song.Id));
        songsUsed[song.Id].UsedBy.Add(name);
    }

    private static void AddRandomSong(Dictionary<int, SongUse> songsUsed, RandomSong randomSong, string name)
    {
        var randomSongIds = Enumerable.Range(randomSong.MinSongId, randomSong.MaxSongId - randomSong.MinSongId);
        foreach (var id in randomSongIds)
        {
            songsUsed.TryAdd(id, new(id));
            songsUsed[id].UsedBy.Add(name);
        }
    }

    private static void AddBattleBgm(Dictionary<int, SongUse> songsUsed, BattleBgm battleBgm, string name)
    {
        var battleMusic = new IMusic?[] { battleBgm.NormalBGM, battleBgm.AdvantageBGM, battleBgm.DisadvantageBGM };
        foreach (var bgm in battleMusic)
        {
            if (bgm is Song battleSong)
            {
                AddSong(songsUsed, battleSong, name);
            }
            else if (bgm is RandomSong battleRandomSong)
            {
                AddRandomSong(songsUsed, battleRandomSong, name);
            }
        }
    }
}
