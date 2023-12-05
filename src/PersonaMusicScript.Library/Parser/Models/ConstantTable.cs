using PersonaMusicScript.Types.Music;

namespace PersonaMusicScript.Library.Parser.Models;

public class ConstantTable : Dictionary<string, object>
{
    public ConstantTable()
    {
        this.Add("DISABLE_BGM", new DisableMusic());
        foreach (var bgmType in Enum.GetValues<PmdBgmType>())
        {
            this.Add(bgmType.ToString(), bgmType);
        }
    }
}
