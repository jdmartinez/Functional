using Shouldly;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void ToOption_WhenNull_ReturnsOptionNone()
    {
        var test = default(TestClass);
        var options = test.ToOption();

            options.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void ToOption_WhenNotNull_ReturnsOption()
    {
        var test = new TestClass();
        var options = test.ToOption();

            options.IsSome.ShouldBeTrue();
    }
}
