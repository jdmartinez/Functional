using Shouldly;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Select_WhenOptionHasValue_ShouldApplySelectorAndReturnNewOption()
    {
        var testValue = "test";
        var option = Option<TestClass>.Some(new TestClass());
        Func<TestClass, string> selector = _ => testValue;

        var result = option.Select(selector);

        result.ShouldBeOfType<Option<string>>();
        result.IsSome.ShouldBeTrue();
            result.Value.ShouldBe(testValue);
    }

    [Fact]
    public void Select_WhenOptionIsNone_ShouldReturnNone()
    {
        var option = Option<TestClass>.None;
        Func<TestClass, string> selector = value => "test";

        var result = option.Select(selector);

        result.ShouldBeOfType<Option<string>>();
        result.IsSome.ShouldBeFalse();
    }
}
