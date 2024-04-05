using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Match_WhenOptionHasValue_ShouldRunSomePredicateAndReturnValue()
    {
        var testClass = new TestClass();
        var option = Option<TestClass>.From(testClass);

        var result = option.Match(value => value.ToString(), () => "none");

        result.Should().Be(testClass.ToString());
    }

    [Fact]
    public void Match_WhenOptionHasNoValue_ShouldRunNonePredicateAndReturnValue()
    {
        var option = Option<TestClass>.From(null!);

        var result = option.Match(value => value.ToString(), () => "none");

        result.Should().Be("none");
    }
}
