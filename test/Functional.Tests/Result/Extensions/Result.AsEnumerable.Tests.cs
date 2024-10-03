using FluentAssertions;

namespace Functional.Tests;

public partial class ResultExtensionsTexts
{
    [Fact]
    public void AsEnumerable_ShouldReturnEnumerable_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var enumerable = result.AsEnumerable();

        // Assert
        enumerable.Should().NotBeEmpty();
        enumerable.Should().Contain(1);
    }

    [Fact]
    public void AsEnumerable_ShouldReturnEmptyEnumerable_WhenResultIsFailure()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("test", "test"));

        // Act
        var enumerable = result.AsEnumerable();

        // Assert
        enumerable.Should().BeEmpty();
    }
}
