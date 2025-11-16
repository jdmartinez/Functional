using Shouldly;

namespace Functional.Tests;

public partial class ResultExtensionsTests
{
    [Fact]
    public async Task Try_ShouldReturnSuccess_WhenFuncDontThrowException()
    {
        // Act
        var result = await Result.Try(() => Task.FromResult(1));

        // Assert
        result.IsSuccess.ShouldBeTrue();
        result.Value.ShouldBe(1);
    }

    [Fact]
    public async Task Try_ShouldReturnFailure_WhenFuncThrowsAnException()
    {
        // Act
        var result = await Result.Try<int>(() => throw new Exception());

        // Assert
        result.IsFailure.ShouldBeTrue();
    }
}
