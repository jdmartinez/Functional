using Shouldly;

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

        result.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public void Can_create_result_failure_from_error()
    {
        var result = Result<TestClass>.Failure(new Error("code", "message"));

        result.IsFailure.ShouldBeTrue();
    }

    [Fact]
    public void Throw_exception_if_create_failure_with_no_error()
    {
        var action = () => { var result = Result<TestClass>.Failure(Error.None); };

        Should.Throw<ArgumentException>(action);
    }

    [Fact]
    public void Can_create_a_result_from_valid_value()
    {
        var test = new TestClass();
        Result<TestClass> result = test;

        result.IsSuccess.ShouldBeTrue();
        result.Value.ShouldBe(test);
    }

    [Fact]
    public void Can_create_a_result_from_valid_error()
    {
        var error = new Error("test", "error");
        Result<TestClass> result = error;

        result.IsFailure.ShouldBeTrue();
        result.Error.ShouldBe(error);
    }

    [Fact]
    public void Success_ShouldReturnResultSuccess_WhenIsSuccess()
    {
        var result = Result.Success();

        result.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public void Success_ShouldReturnResultSuccess_WhenIsValidValue()
    {
        var result = Result.Success(new TestClass());

        result.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public void Failure_ShouldReturnResultFailure_WhenIsAnError()
    {
        var result = Result<TestClass>.Failure(new Error("code", "message"));

        result.IsFailure.ShouldBeTrue();
    }

    [Fact]
    public void Operator_ShouldCreateResultFailure_FromValidValue()
    {
        var test = new TestClass();
        Result<TestClass> result = test;

        result.IsSuccess.ShouldBeTrue();
        result.Value.ShouldBe(test);
    }

    [Fact]
    public void Operator_ShouldCreateResultFailure_FromValidError()
    {
        var error = new Error("test", "error");
        Result<TestClass> result = error;

        result.IsFailure.ShouldBeTrue();
        result.Error.ShouldBe(error);
    }

    [Fact]
    public void OperatorResult_ShouldCreateResultSuccess_FromGenericSuccess()
    {
        var generic = Result.Success(new TestClass());
        var result = (Result)generic;

        result.IsSuccess.ShouldBeTrue();
        result.IsFailure.ShouldBeFalse();
    }

    [Fact]
    public void OperatorResult_ShouldCreateResultFailure_FromGenericFailure()
    {
        var generic = Result.Failure<TestClass>(new Error("test", "test"));
        var result = (Result)generic;

        result.IsSuccess.ShouldBeFalse();
        result.IsFailure.ShouldBeTrue();
    }
}
