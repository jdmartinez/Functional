using FluentAssertions;

namespace Functional.Tests;

public partial class ResultExtensionsTests
{
    [Fact]
    public async Task Then_ShouldReturnTransformedResult_WithSuccessResult()
    {
        // Arrange
        var initialResult = Result.Success(5);
        var resultTask = Task.FromResult(initialResult);

        // Act
        var result = await resultTask.Then(x => Task.FromResult(Result.Success(x * 2)));

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(10);
    }

    [Fact]
    public async Task Then_ShouldReturnFailure_WithFailureResult()
    {
        // Arrange
        var error = new Error("error", "Error");
        var initialResult = Result.Failure<int>(error);
        var resultTask = Task.FromResult(initialResult);

        // Act
        var result = await resultTask.Then(x => Task.FromResult(Result.Success(x * 2)));

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }

    [Fact]
    public async Task Then_ShouldReturnTransformedResult_WithSyncFunction()
    {
        // Arrange
        var initialResult = Result.Success(5);
        var resultTask = Task.FromResult(initialResult);

        // Act
        var result = await resultTask.Then(x => x * 2);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(10);
    }

    [Fact]
    public void Then_ShouldReturnTransformedResult_WithSyncFunctionResult()
    {
        // Arrange
        var initialResult = Result.Success(5);

        // Act
        var result = initialResult.Then(x => Result.Success(x * 2));

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(10);
    }

    [Fact]
    public async Task Then_ShouldReturnTransformedResult_WithAsyncFunctionResult()
    {
        // Arrange
        var initialResult = Result.Success(5);
        var resultTask = Task.FromResult(initialResult);

        // Act
        var result = await resultTask.Then(x => Task.FromResult(Result.Success(x * 2)));

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(10);
    }

    [Fact]
    public async Task Then_ShouldReturnFailure_WithAsyncFunctionResult()
    {
        // Arrange
        var error = new Error("error", "Error");
        var initialResult = Result.Failure<int>(error);
        var resultTask = Task.FromResult(initialResult);

        // Act
        var result = await resultTask.Then(x => Task.FromResult(Result.Success(x * 2)));

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }

    [Fact]
    public async Task Then_ShouldExecuteAction_WithAsyncFunction()
    {
        // Arrange
        var initialResult = Result.Success(5);
        var resultTask = Task.FromResult(initialResult);
        var actionExecuted = false;

        // Act
        await resultTask.Then(x => { actionExecuted = true; return Task.CompletedTask; });

        // Assert
        actionExecuted.Should().BeTrue();
    }
}
