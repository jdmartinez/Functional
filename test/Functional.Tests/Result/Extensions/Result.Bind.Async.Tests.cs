using Shouldly;

namespace Functional.Tests;

public partial class ResultExtensionsTests
{
    [Fact]
    public async Task BindAsync_ShouldReturnSuccess_WhenResultIsSuccess()
    {
        // Arrange
        var resultTask = Result.Success(1).AsTask();

        // Act
        var bindResult = await resultTask.Bind(ToStringAsync);

        // Assert
            bindResult.ShouldBeOfType<Result<string>>();
        bindResult.IsSuccess.ShouldBeTrue();
            bindResult.Value.ShouldBe("1");
    }

    [Fact]
    public async Task BindAsync_ShouldReturnFailure_WhenResultIsFailure()
    {
        // Arrange
        var error = new Error("test", "test");
        var resultTask = Result.Failure<int>(error).AsTask();

        // Act
        var bindResult = await resultTask.Bind(ToStringAsync);

        // Assert
            bindResult.ShouldBeOfType<Result<string>>();
        bindResult.IsFailure.ShouldBeTrue();
            bindResult.Error.ShouldBe(error);
    }

    private static Task<Result<string>> ToStringAsync(int value) => Result.Success(value.ToString()).AsTask();
}
