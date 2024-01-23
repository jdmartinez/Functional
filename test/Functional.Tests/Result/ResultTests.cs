using FluentAssertions;

namespace Functional.Tests.Option;

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
}
