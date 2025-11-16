using Shouldly;
using Shouldly;

namespace Functional.Tests;

public partial class ResultExtensionsTests
{
    [Fact]
    public void Reduce_ShouldReturnResultValue_WhenResultIsSuccess()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var value = result.Reduce(0);

        // Assert
        value.ShouldBe(1);
    }

    [Fact]
    public void Reduce_ShouldReturnDefault_WhenResultIsFailure()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("test", "test"));

        // Act
        var value = result.Reduce(0);

        // Assert
        value.ShouldBe(0);
    }

    [Fact]
    public void Reduce_ShouldReturnResult_WhenResultIsSuccessAndFuncAsDefault()
    {
        // Arrange
        var result = Result.Success(1);

        // Act
        var value = result.Reduce(() => 2);

        // Assert
        value.ShouldBe(1);
    }

    [Fact]
    public void Reduce_ShouldReturnFailure_WhenResultIsFailureAndFuncAsDefault()
    {
        // Arrange
        var result = Result.Failure<int>(new Error("test", "test"));

        // Act
        var value = result.Reduce(() => 0);

        // Assert
        value.ShouldBe(0);
    }
}
