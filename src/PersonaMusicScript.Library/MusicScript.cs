using PersonaMusicScript.Library.Parser.Models;
using PersonaMusicScript.Types;

namespace PersonaMusicScript.Library;

public class MusicScript
{
    public MusicScript(MusicResources resources, ConstantTable constants, MusicSource source)
    {
        this.Resources = resources;
        this.Constants = constants;
        this.Source = source;
    }

    public MusicResources Resources { get; }

    public ConstantTable Constants { get; }

    public MusicSource Source { get; }
}
