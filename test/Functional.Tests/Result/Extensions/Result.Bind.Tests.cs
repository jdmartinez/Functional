using FluentAssertions;

namespace Functional.Tests;

public partial class ResultExtensionsTexts
{
    [Fact]
    public void Bind_ShouldReturnResult_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var bindResult = result.Bind(x => Result.Success(x + 1));

        // Assert
        bindResult.Should().BeOfType<Result<int>>();
        bindResult.IsSuccess.Should().BeTrue();
        bindResult.Value.Should().Be(2);
    }

    [Fact]
    public void Bind_ShouldReturnFailureResult_WhenResultIsFailure()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("test", "test"));

        // Act
        var bindResult = result.Bind(x => Result.Success(x + 1));

        // Assert
        bindResult.Should().BeOfType<Result<int>>();
        bindResult.IsFailure.Should().BeTrue();
        bindResult.Error.Should().NotBeNull();
    }
}
