using FluentAssertions;
using Xunit;

namespace Mowers.Domain.Tests.Unit;
public class LawnTests
{
    private readonly RectangularLawn _sut;

    public LawnTests()
    {
        _sut = new RectangularLawn(5, 5);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(5, 5)]
    [InlineData(1, 4)]
    public void ShouldBeInside(int x, int y)
    {
        var point = new Coordinates(x, y);
        _sut.IsInside(point).Should().BeTrue();
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(0, -1)]
    [InlineData(6, 0)]
    [InlineData(0, 6)]
    [InlineData(6, 6)]
    public void ShouldNotBeInside(int x, int y)
    {
        var point = new Coordinates(x, y);
        _sut.IsInside(point).Should().BeFalse();
    }
}
