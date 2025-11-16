using Shouldly;

namespace Functional.Tests;

public partial class ResultExtensionsTests
{
    [Fact]
    public void Match_ShouldReturnValue_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result.Success(42);

        // Act
        var value = result.Match(
            onSuccess: v => v,
            onFailure: e => 0
        );

        // Assert
        value.ShouldBe(42);
    }

    [Fact]
    public void Match_ShouldReturnDefaultValue_WhenResultIsFailure()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("test", "test"));

        // Act
        var value = result.Match(
            onSuccess: v => v,
            onFailure: e => 0
        );

        // Assert
        value.ShouldBe(0);
    }
}
