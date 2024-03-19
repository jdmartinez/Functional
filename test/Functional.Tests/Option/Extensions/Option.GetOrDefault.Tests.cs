using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void GetOrDefault_WithValue_ShouldReturnOptionValue()
    {
        var test = new TestClass();
        var defaultTest = new TestClass();
        var option = Option.From(test);

        var result = option.GetOrDefault(defaultTest);

        result.Should().Be(test);
    }

    [Fact]
    public void GetOrDefault_WithNone_ShouldReturnDefaultValue()
    {
        var defaultTest = new TestClass();
        var option = Option<TestClass>.None;

        var result = option.GetOrDefault(defaultTest);

        result.Should().Be(defaultTest);
    }

    [Fact]
    public void GetOrDefault_WithFuncAndValue_ShouldReturnOptionValue()
    {
        var test = new TestClass();
        var defaultTest = new TestClass();
        var option = Option.From(test);

        var result = option.GetOrDefault(() => defaultTest);

        result.Should().Be(test);
    }

    [Fact]
    public void GetOrDefault_WithFuncAndNone_ShouldReturnDefaultValue()
    {
        var defaultTest = new TestClass();
        var option = Option<TestClass>.None;

        var result = option.GetOrDefault(() => defaultTest);

        result.Should().Be(defaultTest);
    }

    [Fact]
    public void GetOrDefault_WithOptionAndValue_ShouldReturnOption()
    {
        var test = new TestClass();
        var defaultTest = new TestClass();
        var option = Option.From(test);
        var defaultOption = Option.From(defaultTest);

        var result = option.GetOrDefault(defaultOption);

        result.Should().Be(option);
    }

    [Fact]
    public void GetOrDefault_WithOptionAndNone_ShouldReturnDefaultValue()
    {
        var option = Option<TestClass>.None;
        var defaultTest = new TestClass();
        var defaultValue = Option.From(defaultTest);

        var result = option.GetOrDefault(defaultValue);

        result.Should().Be(defaultValue);
    }

    [Fact]
    public void GetOrDefault_WithFuncOptionAndValue_ShouldReturnOption()
    {
        var test = new TestClass();
        var defaultTest = new TestClass();
        var option = Option.From(test);
        var defaultValue = Option.From(defaultTest);

        // Act
        var result = option.GetOrDefault(() => defaultValue);

        // Assert
        result.Should().Be(option);
    }

    [Fact]
    public void GetOrDefault_WithFuncOptionAndNone_ShouldReturnDefaultValue()
    {
        var defaultTest = new TestClass();
        var option = Option<TestClass>.None;
        var defaultValue = Option.From(defaultTest);

        // Act
        var result = option.GetOrDefault(() => defaultValue);

        // Assert
        result.Should().Be(defaultValue);
    }

    [Fact]
    public void GetOrDefault_WithSelectorAndValue_ShouldApplySelector()
    {
        var test = new TestClass();
        var defaultValue = new TestClass();
        var option = Option.From(test); // Assuming you have an Option class with a static method From

        // Act
        var result = option.GetOrDefault(v => test, defaultValue);

        // Assert
        result.Should().Be(test);
    }

    [Fact]
    public void GetOrDefault_WithSelectorAndNone_ShouldReturnDefaultValue()
    {
        var newTest = new TestClass();
        var defaultValue = Option.From(new TestClass());
        var option = Option<TestClass>.None;

        var result = option.GetOrDefault(_ => newTest, defaultValue);

        result.Should().Be(defaultValue);
    }
}
