using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Or_WhenOptionHasValue_Should_ReturnValue()
    {
        var test = new TestClass();
        var fallback = new TestClass();
        var option = Option<TestClass>.From(test);
        var result = option.Or(fallback);

        result.Value.Should().Be(test);
    }

    [Fact]
    public void Or_WhenOptionNone_Should_ReturnsFallback()
    {
        var fallback = new TestClass();
        var option = Option<TestClass>.From(default!);
        var result = option.Or(fallback);

        result.HasValue.Should().BeTrue();
    }

    [Fact]
    public void Or_WithFunction_WhenOptionHasValue_Should_ReturnValue()
    {
        var test = new TestClass();
        var option = Option<TestClass>.From(test);
        var result = option.Or(() => new TestClass());

        result.Value.Should().Be(test);
    }

    [Fact]
    public void Or_WithFunction_WhenOptionNone_Should_ReturnsFallback()
    {
       var option = Option<TestClass>.From(default!);
        var result = option.Or(() => new TestClass());

        result.HasValue.Should().BeTrue();
    }

    [Fact]
    public void Or_WithOptionFunction_WhenOptionHasValue_Should_ReturnValue()
    {
        var test = new TestClass();
        var option = Option<TestClass>.From(test);
        var result = option.Or(() => Option<TestClass>.From(new TestClass()));

        result.Value.Should().Be(test);
    }

    [Fact]
    public void Or_WithOptionFunction_WhenOptionNone_Should_ReturnsFallback()
    {
        var option = Option<TestClass>.From(default!);
        var result = option.Or(() => Option<TestClass>.From(new TestClass()));

        result.HasValue.Should().BeTrue();
    }
}
