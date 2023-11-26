namespace PersonaMusicScript.Library.Models.Music.Entries;

public class EncounterEntry : BaseEntry
{
    public EncounterEntry(int encounterId)
        : base(encounterId)
    {
        Name = $"Encounter: {encounterId}";
    }

    public EncounterEntry(string collectionName)
        : base(collectionName)
    {
        Name = collectionName;
    }

    public IMusic? BattleMusic { get; set; }

    public IMusic? VictoryMusic { get; set; }
}
