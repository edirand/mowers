using System.Diagnostics.CodeAnalysis;

namespace Mowers.Presentation.Console.Controllers;
[ExcludeFromCodeCoverage]
internal class ConsoleInputController : IInputController
{
    public string? GetNextInput()
    {
        return System.Console.ReadLine();
    }
}
