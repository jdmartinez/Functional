using Shouldly;

namespace Functional.Tests;

public partial class ResultExtensionsTests
{
    [Fact]
    public void AsEnumerable_ShouldReturnEnumerable_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var enumerable = result.AsEnumerable();

        // Assert
           enumerable.ShouldNotBeEmpty();
           enumerable.ShouldContain(1);
    }

    [Fact]
    public void AsEnumerable_ShouldReturnEmptyEnumerable_WhenResultIsFailure()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("test", "test"));

        // Act
        var enumerable = result.AsEnumerable();

        // Assert
           enumerable.ShouldBeEmpty();
    }
}
