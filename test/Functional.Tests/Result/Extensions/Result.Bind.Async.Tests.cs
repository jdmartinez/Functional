using FluentAssertions;

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
        bindResult.Should().BeOfType<Result<string>>();
        bindResult.IsSuccess.Should().BeTrue();
        bindResult.Value.Should().Be("1");
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
        bindResult.Should().BeOfType<Result<string>>();
        bindResult.IsFailure.Should().BeTrue();
        bindResult.Error.Should().Be(error);
    }

    private static Task<Result<string>> ToStringAsync(int value) => Result.Success(value.ToString()).AsTask();
}
