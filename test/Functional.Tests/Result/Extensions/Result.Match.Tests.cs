using FluentAssertions;

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
        value.Should().Be(42);
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
        value.Should().Be(0);
    }
}
