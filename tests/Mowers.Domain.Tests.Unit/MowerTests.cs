using FluentAssertions;
using Xunit;

namespace Mowers.Domain.Tests.Unit;

public class MowerTests
{
    [Theory]
    [InlineData(Direction.N, Direction.W)]
    [InlineData(Direction.W, Direction.S)]
    [InlineData(Direction.S, Direction.E)]
    [InlineData(Direction.E, Direction.N)]
    public void ShouldTurnLeft(Direction orientation, Direction expected)
    {
        var mower = new Mower(0, 0, orientation);
        mower.TurnLeft();
        mower.Orientation.Should().Be(expected);
    }

    [Theory]
    [InlineData(Direction.N, Direction.E)]
    [InlineData(Direction.E, Direction.S)]
    [InlineData(Direction.S, Direction.W)]
    [InlineData(Direction.W, Direction.N)]
    public void ShouldTurnRight(Direction orientation, Direction expected)
    {
        var mower = new Mower(0, 0, orientation);
        mower.TurnRight();
        mower.Orientation.Should().Be(expected);
    }

    [Theory]
    [InlineData(Direction.N, 0, 1)]
    [InlineData(Direction.S, 0, -1)]
    [InlineData(Direction.E, 1, 0)]
    [InlineData(Direction.W, -1, 0)]
    public void ShouldMoveForward(Direction orientation, int expectedX, int expectedY)
    {
        var mower = new Mower(0, 0, orientation);
        mower.MoveForward(new RectangularLawn(5, 5));
        mower.Position.Should().Be(new Coordinates(expectedX, expectedY));
    }

    [Theory]
    [InlineData(0, 0, Direction.W)]
    [InlineData(0, 0, Direction.S)]
    [InlineData(5, 0, Direction.E)]
    [InlineData(0, 5, Direction.N)]
    public void ShouldStayInPositionIfOutsideOfTheLawnAfterMoving(int x, int y, Direction orientation)
    {
        var lawn = new RectangularLawn(5, 5);
        var mower = new Mower(x, y, orientation);
        mower.MoveForward(lawn);
        mower.Position.Should().Be(new Coordinates(x, y));
    }

    [Theory]
    [InlineData(0, 0, Direction.N)]
    [InlineData(2, 4, Direction.S)]
    [InlineData(3, 2, Direction.E)]
    [InlineData(1, 1, Direction.W)]
    public void ShouldPrintStateToString(int x, int y, Direction orientation)
    {
        var mower = new Mower(x, y, orientation);
        var print = mower.ToString();
        print.Should().Be($"{x} {y} {orientation}");
    }
}
