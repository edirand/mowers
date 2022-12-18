namespace Mowers.Domain;
public class RectangularLawn : ILawn
{
    private readonly Coordinates _bottomLeft;
    private readonly Coordinates _topRight;

    public RectangularLawn(uint length, uint width)
    {
        _bottomLeft = new Coordinates(0, 0);
        _topRight = new Coordinates((int)length, (int)width);
    }

    public bool IsInside(Coordinates point)
    {
        if (point.X < _bottomLeft.X) return false;
        if(point.X > _topRight.X) return false;
        if(point.Y < _bottomLeft.Y) return false;
        if (point.Y > _topRight.Y) return false;

        return true;
    }
}
