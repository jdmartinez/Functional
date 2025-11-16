using Shouldly;

namespace Functional.Tests;

public partial class ResultExtensionsTests
{
    [Fact]
    public void Map_ShouldReturnResult_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var mapResult = result.Map(x => x + 1);

        // Assert
        mapResult.ShouldBeOfType<Result<int>>();
        mapResult.IsSuccess.ShouldBeTrue();
        mapResult.Value.ShouldBe(2);
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
        mapResult.ShouldBeOfType<Result<int>>();
        mapResult.IsFailure.ShouldBeTrue();
        mapResult.Error.ShouldBe(error);
    }
}
