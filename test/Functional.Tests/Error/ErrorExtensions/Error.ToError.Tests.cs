using FluentAssertions;

namespace Functional.Tests;

public partial class ErrorExtensionsTests
{
    [Fact]
    public void ToError_ShouldReturnError_WithExceptionCodeAndMessage()
    {
        // Arrange
        var exception = new Exception("exception message");

        // Act
        var error = exception.ToError();

        // Assert
        error.Code.Should().Be(exception.GetType().Name);
        error.Message.Should().Be(exception.Message);
    }
}
