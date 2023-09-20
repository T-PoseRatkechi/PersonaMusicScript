namespace PersonaMusicScript.Library.Models;

internal class Song : IMusic
{
    public Song(int id) => this.Id = id;

    public Song(string name) => this.Name = name;

    public string? Name { get; }

    public int? Id { get; }

    public override bool Equals(object? obj)
    {
        if (obj is Song other)
        {
            if (this.Id == other.Id
                && this.Name == other.Name)
            {
                return true;
            }
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }
}
