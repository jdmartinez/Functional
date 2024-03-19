using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Map_WhenOptionHasValue_ShouldApplySelectorAndReturnNewOption()
    {
        var testValue = "test";
        var option = Option<TestClass>.From(new TestClass());
        Func<TestClass, string> selector = _ => testValue;

        var result = option.Map(selector);

        result.Should().BeOfType<Option<string>>();
        result.HasValue.Should().BeTrue();
        result.Value.Should().Be(testValue);
    }
}
