using FluentAssertions;

namespace Functional.Tests;

public class ResultTests
{
    private class TestClass
    {
        public override string ToString() => "Test class";
    }

    [Fact]
    public void Can_create_result_success_from_value()
    {
        var result = Result.Success(new TestClass());

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Can_create_result_failure_from_error()
    {
        var result = Result<TestClass>.Failure(new Error("code", "message"));

        result.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void Throw_exception_if_create_failure_with_no_error()
    {
        var action = () => { var result = Result<TestClass>.Failure(Error.None); };

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Can_create_a_result_from_valid_value()
    {
        var test = new TestClass();
        Result<TestClass> result = test;

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(test);
    }

    [Fact]
    public void Can_create_a_result_from_valid_error()
    {
        var error = new Error("test", "error");
        Result<TestClass> result = error;

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }

    [Fact]
    public void Success_ShouldReturnResultSuccess_WhenIsSuccess()
    {
        var result = Result.Success();

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Success_ShouldReturnResultSuccess_WhenIsValidValue()
    {
        var result = Result.Success(new TestClass());

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Failure_ShouldReturnResultFailure_WhenIsAnError()
    {
        var result = Result<TestClass>.Failure(new Error("code", "message"));

        result.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void Operator_ShouldCreateResultFailure_FromValidValue()
    {
        var test = new TestClass();
        Result<TestClass> result = test;

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(test);
    }

    [Fact]
    public void Operator_ShouldCreateResultFailure_FromValidError()
    {
        var error = new Error("test", "error");
        Result<TestClass> result = error;

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }

    [Fact]
    public void OperatorResult_ShouldCreateResultSuccess_FromGenericSuccess()
    {
        var generic = Result.Success(new TestClass());
        var result = generic;

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
    }

    [Fact]
    public void OperatorResult_ShouldCreateResultFailure_FromGenericFailure()
    {
        var generic = Result.Failure<TestClass>(new Error("test", "test"));
        var result = generic;

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
    }
}
