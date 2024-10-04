using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Reduce_WithValue_ShouldReturnOptionValue()
    {
        var test = new TestClass();
        var defaultTest = new TestClass();
        var option = Option.Some(test);

        var result = option.Reduce(defaultTest);

        result.Should().Be(test);
    }

    [Fact]
    public void Reduce_WithNone_ShouldReturnDefaultValue()
    {
        var defaultTest = new TestClass();
        var option = Option<TestClass>.None;

        var result = option.Reduce(defaultTest);

        result.Should().Be(defaultTest);
    }

    [Fact]
    public void Reduce_WithFuncAndValue_ShouldReturnOptionValue()
    {
        var test = new TestClass();
        var defaultTest = new TestClass();
        var option = Option.Some(test);

        var result = option.Reduce(() => defaultTest);

        result.Should().Be(test);
    }

    [Fact]
    public void Reduce_WithFuncAndNone_ShouldReturnDefaultValue()
    {
        var defaultTest = new TestClass();
        var option = Option<TestClass>.None;

        var result = option.Reduce(() => defaultTest);

        result.Should().Be(defaultTest);
    }

    [Fact]
    public void Reduce_WithOptionAndValue_ShouldReturnOption()
    {
        var test = new TestClass();
        var defaultTest = new TestClass();
        var option = Option.Some(test);
        var defaultOption = Option.Some(defaultTest);

        var result = option.Reduce(defaultOption);

        result.Should().Be(option);
    }

    [Fact]
    public void Reduce_WithOptionAndNone_ShouldReturnDefaultValue()
    {
        var option = Option<TestClass>.None;
        var defaultTest = new TestClass();
        var defaultValue = Option.Some(defaultTest);

        var result = option.Reduce(defaultValue);

        result.Should().Be(defaultValue);
    }

    [Fact]
    public void Reduce_WithFuncOptionAndValue_ShouldReturnOption()
    {
        var test = new TestClass();
        var defaultTest = new TestClass();
        var option = Option.Some(test);
        var defaultValue = Option.Some(defaultTest);

        // Act
        var result = option.Reduce(() => defaultValue);

        // Assert
        result.Should().Be(option);
    }

    [Fact]
    public void Reduce_WithFuncOptionAndNone_ShouldReturnDefaultValue()
    {
        var defaultTest = new TestClass();
        var option = Option<TestClass>.None;
        var defaultValue = Option.Some(defaultTest);

        // Act
        var result = option.Reduce(() => defaultValue);

        // Assert
        result.Should().Be(defaultValue);
    }

    [Fact]
    public void Reduce_WithSelectorAndValue_ShouldApplySelector()
    {
        var test = new TestClass();
        var defaultValue = new TestClass();
        var option = Option.Some(test); // Assuming you have an Option class with a static method From

        // Act
        var result = option.Reduce(v => test, defaultValue);

        // Assert
        result.Should().Be(test);
    }

    [Fact]
    public void Reduce_WithSelectorAndNone_ShouldReturnDefaultValue()
    {
        var newTest = new TestClass();
        var defaultValue = Option.Some(new TestClass());
        var option = Option<TestClass>.None;

        var result = option.Reduce(_ => newTest, defaultValue);

        result.Should().Be(defaultValue);
    }
}
