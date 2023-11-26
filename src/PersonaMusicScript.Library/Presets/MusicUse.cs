using PersonaMusicScript.Types.Music;
using PersonaMusicScript.Types.MusicCollections.Entries;

namespace PersonaMusicScript.Library.Presets;

internal class MusicUse : Dictionary<int, HashSet<string>>
{
    public MusicUse(MusicSource source)
    {
        foreach (var encounter in source.Encounters)
        {
            this.AddEncounterMusic(encounter.Value);
        }

        foreach (var floor in source.Floors)
        {
            this.AddMusic("Floor BGM", floor.Value);
        }

        foreach (var evt in source.Events)
        {
            foreach (var frame in evt.Value.Frames)
            {
                if (frame.Value != null)
                {
                    this.AddMusic($"Event {evt.Key.MajorId} / {evt.Key.MinorId}", frame.Value);
                }
            }
        }

        foreach (var global in source.Global)
        {
            this.AddMusic("Global BGM", global.Value);
        }
    }

    public void AddEncounterMusic(EncounterEntry encounter)
    {
        var name = encounter.Name != null ? $"{encounter.Name} | " : string.Empty;
        if (encounter.BattleMusic != null)
        {
            this.AddMusic($"{name}Battle", encounter.BattleMusic);
        }

        if (encounter.VictoryMusic != null)
        {
            this.AddMusic($"{name}Victory", encounter.VictoryMusic);
        }
    }

    private void AddMusic(string name, IMusic music)
    {
        if (music is Song song)
        {
            if (!this.ContainsKey(song.Id))
            {
                this[song.Id] = new();
            }

            this[song.Id].Add(name);
        }
        else if (music is RandomSong randomSong)
        {
            var range = Enumerable.Range(randomSong.MinSongId, randomSong.MaxSongId - randomSong.MinSongId);
            foreach (var id in range)
            {
                if (!this.ContainsKey(id))
                {
                    this[id] = new();
                }

                this[id].Add(name);
                this[id].Add($"random_song({randomSong.MinSongId}, {randomSong.MaxSongId - 1})");
            }
        }
        else if (music is BattleBgm battleBgm)
        {
            if (battleBgm.NormalMusic != null)
            {
                this.AddMusic($"{name}: Normal", battleBgm.NormalMusic);
            }

            if (battleBgm.AdvantageMusic != null)
            {
                this.AddMusic($"{name}: Advantage", battleBgm.AdvantageMusic);
            }

            if (battleBgm.DisadvantageMusic != null)
            {
                this.AddMusic($"{name}: Disadvantage", battleBgm.DisadvantageMusic);
            }
        }
        else if (music is Sound sound)
        {
            this.AddMusic(name, sound.Music);
        }
        else if (music is FrameBgm frameBgm && frameBgm.Music != null)
        {
            this.AddMusic(name, frameBgm.Music);
        }
        else if (music is DisableMusic)
        {
        }
        else
        {
            throw new Exception("Unknown music type.");
        }
    }
}
