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
        result.Errors.Count().Should().Be(1);
    }

    [Fact]
    public void Can_create_a_result_failure_from_error_list()
    {
        var errors = new List<Error>
        {
            new("1", "error 1"),
            new("2", "error 2"),
        };
        var result = Result<TestClass>.Failure(errors);

        result.IsFailure.Should().BeTrue();
        result.Errors.Count().Should().Be(errors.Count);
    }
}
