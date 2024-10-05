using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Bind_WhenOptionHasValue_ShouldApplySelectorAndReturnNewOption()
    {
        var testValue = "test";
        var option = Option.Some(new TestClass());
        Func<TestClass, Option<string>> selector = _ => testValue;

        var result = option.Bind(selector);

        result.Should().BeOfType<Option<string>>();
        result.IsSome.Should().BeTrue();
        result.Value.Should().Be(testValue);
    }

    [Fact]
    public void Bind_WhenOptionIsNone_ShouldReturnNone()
    {
        // Arrange
        var option = Option<TestClass>.None;
        Func<TestClass, Option<string>> selector = value => "test";

        // Act
        var result = option.Bind(selector);

        // Assert
        result.Should().BeOfType<Option<string>>();
        result.IsSome.Should().BeFalse();
    }
}
