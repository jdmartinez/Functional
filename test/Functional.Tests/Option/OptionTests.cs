using FluentAssertions;

namespace Functional.Tests;

public class OptionTests
{
    private class TestClass
    {
        public override string ToString() => "Test class";
    }

    [Fact]
    public void Can_create_an_option_from_null()
    {
        var opt = Option<TestClass>.From(null!);

        opt.HasValue.Should().BeFalse();
    }

    [Fact]
    public void Can_create_an_option_from_null_literal()
    {
        var opt = (Option<TestClass>)null!;

        opt.HasValue.Should().BeFalse();
    }

    [Fact]
    public void Can_create_an_option_none()
    {
        var opt = Option<TestClass>.None;

        opt.HasValue.Should().BeFalse();
    }

    [Fact]
    public void Nullable_literal_option_and_none_option_are_the_same()
    {
        var nullOpt = (Option<TestClass>)null!;
        var opt = Option<TestClass>.None;

        opt.Should().Be(nullOpt);
    }

    [Fact]
    public void Throw_exception_if_access_value_of_none()
    {
        var nullOpt = (Option<TestClass>)null!;
        var action = () => { var test = nullOpt.Value; };

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Can_create_an_option_from_valid_value()
    {
        var test = new TestClass();
        Option<TestClass> opt = test;

        opt.HasValue.Should().BeTrue();
        opt.Value.Should().Be(test);
    }

    [Fact]
    public void ToString_returns_object_string_representation()
    {
        Option<TestClass> opt = new TestClass();
        var str = opt.ToString();

        str.Should().Be("Test class");
    }

    [Fact]
    public void None_option_has_no_value()
    {
        Option<string>.None.HasValue.Should().BeFalse();
        Option<int>.None.HasValue.Should().BeFalse();
    }

    [Fact]
    public void None_option_tuple_has_no_value()
    {
        Option<(Array, Exception)>.None.HasValue.Should().BeFalse();
        Option<(DateTime, bool, char)>.None.HasValue.Should().BeFalse();
        Option<(string, TimeSpan)>.None.HasValue.Should().BeFalse();
    }

    [Fact]
    public void Can_cast_non_generic_option_none_to_option_none()
    {
        Option<int> opt = Functional.Option.None;

        opt.HasValue.Should().BeFalse();
    }

    [Fact]
    public void Option_From_creates_a_new_option()
    {
        var nonGenericOpt = Functional.Option.From("test");
        var genericOpt = Option<string>.From("test");
        var otherOpt = Option<string>.From("other");

        nonGenericOpt.Should().Be(genericOpt);
        nonGenericOpt.Should().NotBe(otherOpt);
    }
}
