using FluentAssertions;

namespace Functional.Facts;

public partial class ResultExtensionsTests
{
    [Fact]
    public void Tap_ShouldReturnSuccess_WhenResultIsSuccessWithAction()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var actual = result.Tap(() => { });

        // Assert
        actual.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Tap_ShouldReturnFailure_WhenResultIsFailureWithAction()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("Fact", "Fact"));

        // Act
        var actual = result.Tap(() => { });

        // Assert
        actual.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void Tap_ShouldReturnSuccess_WhenResultIsSuccessWithActionWithArgument()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var actual = result.Tap(v => { });

        // Assert
        actual.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Tap_ShouldReturnFailure_WhenResultIsFailureWithActionWithArgument()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("Fact", "Fact"));

        // Act
        var actual = result.Tap(value => { });

        // Assert
        actual.IsFailure.Should().BeTrue();
    }

    [Fact]
    public async Task Tap_ShouldReturnSuccess_WhenResultIsSuccessWithFuncThatReturnsTask()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var actual = await result.Tap(() => Task.CompletedTask);

        // Assert
        actual.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Tap_ShouldReturnFailure_WhenResultIsSuccessWithFuncThatReturnsTask()
    {
        var result = Result.Failure<int>(new Error("Fact", "Fact"));

        var actual = await result.Tap(() => Task.CompletedTask);

        // Assert
        actual.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Tap_ShouldReturnSuccess_WhenResultIsSuccessWithFuncWithArgumentThatReturnsTask()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var actual = await result.Tap(() => Task.CompletedTask);

        // Assert
        actual.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Tap_ShouldReturnFailure_WhenResultIsFailureWithFuncWithArgumentThatReturnsTask()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("Fact", "Fact"));

        // Act
        var actual = await result.Tap(() => Task.CompletedTask);

        // Assert
        actual.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Tap_ShouldReturnSuccess_WhenResultIsTaskWithFuncWithArgumentThatReturnsTask()
    {
        // Arrange
        var result = Task.FromResult(Result.Success(1));

        // Act
        var actual = await result.Tap(value => Task.CompletedTask);

        // Assert
        actual.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Tap_ShouldReturnFailure_WhenResultIsTaskWithFuncWithArgumentThatReturnsTask()
    {
        // Arrange
        var result = Task.FromResult(Result.Failure<int>(new Error("Fact", "Fact")));

        // Act
        var actual = await result.Tap(value => Task.CompletedTask);

        // Assert
        actual.IsSuccess.Should().BeFalse();
    }
}
