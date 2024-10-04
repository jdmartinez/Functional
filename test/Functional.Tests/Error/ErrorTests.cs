using FluentAssertions;

namespace Functional.Tests;

public class ErrorTests
{
    [Fact]
    public void Constructor_ShouldCreateEmptyError_WhenNoArguments()
    {
        // Arrange
        var error = new Error();

        // Assert
        error.Code.Should().BeEmpty();
        error.Message.Should().BeEmpty();
    }

    [Fact]
    public void Code_ShouldReturnCode()
    {
        // Arrange
        var error = new Error("code", "message");

        // Assert
        error.Code.Should().Be("code");
    }

    [Fact]
    public void Message_ShouldReturnCode()
    {
        // Arrange
        var error = new Error("code", "message");

        // Assert
        error.Message.Should().Be("message");
    }

    [Fact]
    public void ToString_ShouldReturnMessage()
    {
        // Arrange
        var error = new Error("code", "message");

        // Act
        var result = error.ToString();

        // Assert
        result.Should().Be(error.Message);
    }

    [Fact]
    public void None_ShouldReturnNullCodeAndMessage()
    {
        var error = Error.None;

        error.Code.Should().BeEmpty();
        error.Message.Should().BeEmpty();
    }
}
