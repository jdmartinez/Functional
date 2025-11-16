using Shouldly;

namespace Functional.Tests;

public partial class ResultExtensionsTests
{
    [Fact]
    public void Bind_ShouldReturnResult_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var bindResult = result.Bind(x => Result.Success(x + 1));

        // Assert
        bindResult.ShouldBeOfType<Result<int>>();
        bindResult.IsSuccess.ShouldBeTrue();
        bindResult.Value.ShouldBe(2);
    }

    [Fact]
    public void Bind_ShouldReturnFailureResult_WhenResultIsFailure()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("test", "test"));

        // Act
        var bindResult = result.Bind(x => Result.Success(x + 1));

        // Assert
        bindResult.ShouldBeOfType<Result<int>>();
        bindResult.IsFailure.ShouldBeTrue();
        bindResult.Error.ShouldNotBe(default(Error));
    }
}
