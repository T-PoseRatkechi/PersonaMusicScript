using LibellusLibrary.Event.Types.Frame;

namespace PersonaMusicScript.Library.Parser.Models;

internal class ConstantTable : Dictionary<string, object>
{
    public ConstantTable()
    {
        foreach (var bgmType in Enum.GetValues<PmdBgmType>())
        {
            this.Add(bgmType.ToString(), bgmType);
        }
    }
}
