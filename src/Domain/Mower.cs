namespace Mowers.Domain;
public class Mower : IMower
{
    public Coordinates Position { get; private set; }
    public Direction Orientation => _orientations[_orientation];

    private readonly List<Direction> _orientations;
    private int _orientation;

    public Mower(int x, int y, Direction orientation)
    {
        Position = new Coordinates(x, y);
        _orientations = new() { Direction.N, Direction.E, Direction.S, Direction.W };
        _orientation = _orientations.IndexOf(orientation);
    }

    public void TurnRight()
    {
        _orientation = (_orientation + 1) % _orientations.Count;
    }

    public void TurnLeft()
    {
        _orientation -= 1;
        if (_orientation < 0) 
            _orientation = _orientations.Count-1;
    }

    public void MoveForward(ILawn lawn)
    {
        var nextPosition = Orientation switch
        {
            Direction.N => Position with { Y = Position.Y + 1 },
            Direction.E => Position with { X = Position.X + 1 },
            Direction.S => Position with { Y = Position.Y - 1 },
            Direction.W => Position with { X = Position.X - 1 }
        };

        if (!lawn.IsInside(nextPosition)) return;

        Position = nextPosition;
    }

    public override string ToString()
    {
        return $"{Position.X} {Position.Y} {Orientation}";
    }
}
