using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Or_WhenOptionHasValue_Should_ReturnValue()
    {
        var test = new TestClass();
        var fallback = new TestClass();
        var option = Option<TestClass>.Some(test);
        var result = option.Or(fallback);

        result.Value.Should().Be(test);
    }

    [Fact]
    public void Or_WhenOptionNone_Should_ReturnsFallback()
    {
        var fallback = new TestClass();
        var option = Option<TestClass>.Some(default!);
        var result = option.Or(fallback);

        result.IsSome.Should().BeTrue();
    }

    [Fact]
    public void Or_WithFunction_WhenOptionHasValue_Should_ReturnValue()
    {
        var test = new TestClass();
        var option = Option<TestClass>.Some(test);
        var result = option.Or(() => new TestClass());

        result.Value.Should().Be(test);
    }

    [Fact]
    public void Or_WithFunction_WhenOptionNone_Should_ReturnsFallback()
    {
       var option = Option<TestClass>.Some(default!);
        var result = option.Or(() => new TestClass());

        result.IsSome.Should().BeTrue();
    }

    [Fact]
    public void Or_WithOptionFunction_WhenOptionHasValue_Should_ReturnValue()
    {
        var test = new TestClass();
        var option = Option<TestClass>.Some(test);
        var result = option.Or(() => Option<TestClass>.Some(new TestClass()));

        result.Value.Should().Be(test);
    }

    [Fact]
    public void Or_WithOptionFunction_WhenOptionNone_Should_ReturnsFallback()
    {
        var option = Option<TestClass>.Some(default!);
        var result = option.Or(() => Option<TestClass>.Some(new TestClass()));

        result.IsSome.Should().BeTrue();
    }
}
