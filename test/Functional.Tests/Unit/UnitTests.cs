using Shouldly;

namespace Functional.Tests;

public class UnitTests
{
    [Fact]
    public void Constructor_ShouldCreateUnit()
    {
        var unit = new Unit();

        unit.ShouldBe(Unit.Default);
    }

    [Fact]
    public void Default_ShouldReturnUnitInstance()
    {
        Unit.Default.ShouldBe(Unit.Default);
    }

    [Fact]
    public void GetHashCode_ShouldReturnZero()
    {
        Unit.Default.GetHashCode().ShouldBe(0);
    }

    [Fact]
    public void ToString_ShouldReturnStringRepresentation()
    {
        Unit.Default.ToString().ShouldBe("Unit:()");
    }
}
