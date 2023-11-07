namespace PersonaMusicScript.Library.Models;

public class Encounter
{
    public string? Name { get; set; }

    public IMusic? BattleMusic { get; set; }

    public IMusic? VictoryMusic { get; set; }
}
