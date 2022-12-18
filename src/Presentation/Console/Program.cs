// See https://aka.ms/new-console-template for more information

using Mowers.Domain;
using Mowers.Presentation.Console.Controllers;

Console.WriteLine("Hello, World!");

IInputController inputController;

if (args[0] == "-it")
    inputController = new ConsoleInputController();
else
{
    var filePath = args[0];
    inputController = new FileInputController(filePath);
}

var upperRightCornerCoordinates = inputController.GetNextInput().Split(" ");
ILawn lawn = new RectangularLawn(uint.Parse(upperRightCornerCoordinates[0]), uint.Parse(upperRightCornerCoordinates[1]));

List<IMower> mowers = new List<IMower>();
while (true)
{
    var line = inputController.GetNextInput();
    if (string.IsNullOrWhiteSpace(line)) break;

    var mowerPosition = line.Split(" ");
    var mower = new Mower(int.Parse(mowerPosition[0]), int.Parse(mowerPosition[1]), Enum.Parse<Direction>(mowerPosition[2]));
    var commands = inputController.GetNextInput();
    if(commands == null) break;
    
    foreach (var command in commands)
    {
        if(command == 'L') mower.TurnLeft();
        if(command == 'R') mower.TurnRight();
        if(command == 'F') mower.MoveForward(lawn);
    }
    mowers.Add(mower);
}

Console.WriteLine("Result");
foreach (var mower in mowers)
{
    Console.WriteLine(mower);
}
Console.ReadLine();