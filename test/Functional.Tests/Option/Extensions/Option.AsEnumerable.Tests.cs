using Shouldly;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    private class TestClass
    {
        public string Id { get; set; } = "Test class";

        public override string ToString() => Id;
    }

    [Fact]
    public void Can_create_an_enumerable_from_valid_option()
    {
        var test = new TestClass();
        Option<TestClass> opt = test;

        var enumerable = opt.AsEnumerable();

        enumerable.ShouldBeAssignableTo<IEnumerable<TestClass>>();
        enumerable.ShouldNotBeEmpty();
        enumerable.First().ShouldBe(test);
    }

    [Fact]
    public void AsEnumerable_from_option_nome_must_be_empty_enumerable()
    {
        var opt = Option<TestClass>.None;
        var enumerable = opt.AsEnumerable();

        enumerable.ShouldBeAssignableTo<IEnumerable<TestClass>>();
        enumerable.ShouldBeEmpty();
    }
}
