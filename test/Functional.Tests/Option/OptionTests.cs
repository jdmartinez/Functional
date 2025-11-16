using System.Configuration;
using Shouldly;

namespace Functional.Tests;

public partial class OptionTests
{
    [Serializable]
    private class TestClass
    {
        public string Id { get; set; } = "Test class";

        public override string ToString() => Id;
    }

    [Fact]
    public void Can_create_an_option_from_null()
    {
        var opt = Option<TestClass>.Some(null!);

        opt.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void Can_create_an_option_from_null_literal()
    {
        var opt = (Option<TestClass>)null!;

        opt.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void Can_create_an_option_none()
    {
        var opt = Option<TestClass>.None;

        opt.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void Nullable_literal_option_and_none_option_are_the_same()
    {
        var nullOpt = (Option<TestClass>)null!;
        var opt = Option<TestClass>.None;

        opt.ShouldBe(nullOpt);
    }

    [Fact]
    public void Throw_exception_if_access_value_of_none_from_null_literal()
    {
        var nullOpt = (Option<TestClass>)null!;
        var action = () => { var test = nullOpt.Value; };

        Should.Throw<InvalidOperationException>(action);
    }

    [Fact]
    public void Throw_exeption_if_access_value_of_none()
    {
        var nullOpt = Option<TestClass>.None;
        var action = () => { var test = nullOpt.Value; };

        Should.Throw<InvalidOperationException>(action);
    }

    [Fact]
    public void Can_create_an_option_from_valid_value()
    {
        var test = new TestClass();
        Option<TestClass> opt = test;

        opt.IsSome.ShouldBeTrue();
        opt.Value.ShouldBe(test);
    }

    [Fact]
    public void ToString_returns_object_string_representation()
    {
        Option<TestClass> opt = new TestClass();
        var str = opt.ToString();

        str.ShouldBe("Test class");
    }

    [Fact]
    public void None_option_has_no_value()
    {
        Option<string>.None.IsSome.ShouldBeFalse();
        Option<int>.None.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void None_option_tuple_has_no_value()
    {
        Option<(Array, Exception)>.None.IsSome.ShouldBeFalse();
        Option<(DateTime, bool, char)>.None.IsSome.ShouldBeFalse();
        Option<(string, TimeSpan)>.None.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void Can_cast_non_generic_option_none_to_option_none()
    {
        Option<int> opt = Option.None;

        opt.IsSome.ShouldBeFalse();
    }

    [Fact]
    public void Option_Some_creates_a_new_option()
    {
        var nonGenericOpt = Option.Some("test");
        var genericOpt = Option<string>.Some("test");
        var otherOpt = Option<string>.Some("other");

        nonGenericOpt.ShouldBe(genericOpt);
        nonGenericOpt.ShouldNotBe(otherOpt);
    }

    [Fact]
    public void GetHashCode_ShouldReturnZero_WhenNone()
    {
        var option = Option<TestClass>.None;

        option.GetHashCode().ShouldBe(0);
    }

    [Fact]
    public void GetHashCode_ShouldReturnValidValue_WhenSome()
    {
        var option = Option.Some(new TestClass());

        option.GetHashCode().ShouldNotBe(0);
    }
}
