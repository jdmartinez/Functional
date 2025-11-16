using Shouldly;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Choose_should_return_enumerable_values()
    {
        var test = new TestClass();
        var options = new List<Option<TestClass>>
        {
            test,
            default!,
        };

        var result = options.Choose();

        result.Count().ShouldBe(1);
        result.First().ShouldBe(test);
    }

    [Fact]
    public void Choose_should_return_empty_enumerable()
    {
        var options = new List<Option<TestClass>> { default! };

        var result = options.Choose();

        result.ShouldBeEmpty();
    }
}
