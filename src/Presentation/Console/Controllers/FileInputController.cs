namespace Mowers.Presentation.Console.Controllers;
internal class FileInputController : IInputController
{
    private readonly string[] _lines;
    private int _index;

    public FileInputController(string filePath)
    {
        _lines = File.ReadAllLines(Path.GetFullPath(filePath));
        _index = 0;
    }

    public string? GetNextInput()
    {
        if (_index >= _lines.Length) return null;

        var line = _lines[_index];
        _index++;
        return line;
    }
}
