using FluentAssertions;

namespace Functional.Tests;

public partial class ResultExtensionsTexts
{
    [Fact]
    public void Map_ShouldReturnResult_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var mapResult = result.Map(x => x + 1);

        // Assert
        mapResult.Should().BeOfType<Result<int>>();
        mapResult.IsSuccess.Should().BeTrue();
        mapResult.Value.Should().Be(2);
    }

    [Fact]
    public void Map_ShouldReturnFailureResult_WhenResultIsFailure()
    {
        // Arrange
        var error = new Error("test", "test");
        var result = Result.Failure<int>(error);

        // Act
        var mapResult = result.Map(x => x + 1);

        // Assert
        mapResult.Should().BeOfType<Result<int>>();
        mapResult.IsFailure.Should().BeTrue();
        mapResult.Error.Should().Be(error);
    }
}
