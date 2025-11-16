using Shouldly;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Match_WhenOptionHasValue_ShouldRunSomePredicateAndReturnValue()
    {
        var testClass = new TestClass();
        var option = Option<TestClass>.Some(testClass);

        var result = option.Match(value => value.ToString(), () => "none");

        result.ShouldBe(testClass.ToString());
    }

    [Fact]
    public void Match_WhenOptionHasNoValue_ShouldRunNonePredicateAndReturnValue()
    {
        var option = Option<TestClass>.Some(null!);

        var result = option.Match(value => value.ToString(), () => "none");

        result.ShouldBe("none");
    }
}
