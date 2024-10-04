using FluentAssertions;
using Xunit.Sdk;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void ToResult_WhenOptionHasValue_Should_ReturnSuccessResult()
    {
        var option = Option<TestClass>.Some(new TestClass());
        var result = option.ToResult(new Error());

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void ToResult_WhenOptionIsNone_Should_ReturnFailureResult()
    {
        var option = Option<TestClass>.Some(default!);
        var result = option.ToResult(new Error("1", "error"));

        result.IsFailure.Should().BeTrue();
    }
}
