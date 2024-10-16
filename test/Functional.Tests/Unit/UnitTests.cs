using System;
using FluentAssertions;

namespace Functional.Tests;

public class UnitTests
{
    [Fact]
    public void Constructor_ShouldCreateUnit()
    {
        var unit = new Unit();

        unit.Should().NotBeNull();
    }

    [Fact]
    public void Default_ShouldReturnUnitInstance()
    {
        Unit.Default.Should().NotBeNull();
    }

    [Fact]
    public void GetHashCode_ShouldReturnZero()
    {
        Unit.Default.GetHashCode().Should().Be(0);
    }

    [Fact]
    public void ToString_ShouldReturnStringRepresentation()
    {
        Unit.Default.ToString().Should().Be("Unit:()");
    }
}
