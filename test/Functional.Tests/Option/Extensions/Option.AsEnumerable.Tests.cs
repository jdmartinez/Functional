using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    private class TestClass
    {
        public override string ToString() => "Test class";
    }

    [Fact]
    public void Can_create_an_enumerable_from_valid_option()
    {
        var test = new TestClass();
        Option<TestClass> opt = test;

        var enumerable = opt.AsEnumerable();

        enumerable.Should().BeAssignableTo<IEnumerable<TestClass>>();
        enumerable.Should().NotBeEmpty();
        enumerable.First().Should().Be(test);
    }

    [Fact]
    public void AsEnumerable_from_option_nome_must_be_empty_enumerable()
    {
        var opt = Option<TestClass>.None;
        var enumerable = opt.AsEnumerable();

        enumerable.Should().BeAssignableTo<IEnumerable<TestClass>>();
        enumerable.Should().BeEmpty();
    }
}
