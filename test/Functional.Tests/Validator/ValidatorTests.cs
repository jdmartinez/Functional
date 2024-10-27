using FluentAssertions;

namespace Functional.Tests;

public class ValidatorTests
{
    private record TestClass(int Value);

    [Fact]
    public void Of_ShouldReturn_Validator()
    {
        var test = new TestClass(0);
        var validator = Validator.Of(test);

        validator.Value.Should().Be(test);
    }

    [Fact]
    public void Validate_ShouldReturnSuccess_WhenValidationPasses()
    {
        var test = new TestClass(1);
        var result = Validator.Of(test)
            .Ensure(t => t.Value, v => v > 0, "Value must be greater than 0")
            .Validate();

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(test);
    }

    [Fact]
    public void Validate_ShouldReturnFailure_WhenValidationFails()
    {
        var test = new TestClass(0);
        var result = Validator.Of(test)
            .Ensure(t => t.Value, v => v > 0, "Value must be greater than 0")
            .Validate();

        result.IsFailure.Should().BeTrue();
        result.Errors.Should().ContainSingle();
        result.Errors[0].Message.Should().Be("Value must be greater than 0");
    }

    [Fact]
    public void Validate_ShouldReturnFailure_WhenOneValidationFails()
    {
        var test = new TestClass(10);
        var result = Validator.Of(test)
            .Ensure(t => t.Value, v => v > 0, "Value must be greater than 0")
            .Ensure(t => t.Value, v => v < 10, "Value must be lower than 10")
            .Ensure(t => t.Value, v => v % 2 == 0, "Value must be even")
            .Validate();

        result.IsFailure.Should().BeTrue();
        result.Errors.Should().ContainSingle();
        result.Errors[0].Message.Should().Be("Value must be lower than 10");
    }
}
