namespace PersonaMusicScript.Library.Compiler;

public interface IMusicCompiler
{
    void Compile(Music music, List<string> patch, string outputDir);
}
