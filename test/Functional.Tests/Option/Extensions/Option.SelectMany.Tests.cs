using Shouldly;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void SelectMany_ShouldReturnProjectedValue_WithValidOption()
    {
        // Arrange
        var option = Option.Some(5);
        Func<int, Option<int>> selector = x => x + 5;
        Func<int, int, int> projector = (x, y) => x * y;

        // Act
        var result = option.SelectMany(selector, projector);

        // Assert
        result.IsSome.ShouldBeTrue();
        result.Value.ShouldBe(50);
    }

    [Fact]
    public void SelectMany_ShouldReturnNone_WithNoneOption()
    {
        // Arrange
        var option = Option<int>.None;
        Func<int, Option<int>> selector = x => x + 5;
        Func<int, int, int> projector = (x, y) => x * y;

        // Act
        var result = option.SelectMany(selector, projector);

        // Assert
        result.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void SelectMany_ShouldReturnNone_WithNoneInSelector()
    {
        // Arrange
        var option = Option.Some(5);
        Func<int, Option<int>> selector = x => Option<int>.None;
        Func<int, int, int> projector = (x, y) => x * y;

        // Act
        var result = option.SelectMany(selector, projector);

        // Assert
        result.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void SelectMany_ShouldReturnValidOption_WithoutProjection()
    {
        // Arrange
        var option = Option.Some(5);
        Func<int, Option<int>> selector = x => x + 5;

        // Act
        var result = option.SelectMany(selector);

        // Assert
        result.IsSome.ShouldBeTrue();
        result.Value.ShouldBe(10);
    }

    [Fact]
    public void SelectMany_ShouldReturnNone_WithoutProjection_WithNoneOption()
    {
        // Arrange
        var option = Option<int>.None;
        Func<int, Option<int>> selector = x => x + 5;

        // Act
        var result = option.SelectMany(selector);

        // Assert
        result.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void SelectMany_ShouldReturnNone_WithoutProjection_WithNoneInSelector()
    {
        // Arrange
        var option = Option.Some(5);
        Func<int, Option<int>> selector = x => Option<int>.None;

        // Act
        var result = option.SelectMany(selector);

        // Assert
        result.IsSome.ShouldBeFalse();
    }
}
