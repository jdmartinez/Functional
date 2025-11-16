using Shouldly;

namespace Functional.Tests;

public class ErrorTests
{
    [Fact]
    public void Constructor_ShouldCreateEmptyError_WhenNoArguments()
    {
        // Arrange
        var error = new Error();

        // Assert
        error.Code.ShouldBe(string.Empty);
        error.Message.ShouldBe(string.Empty);
    }

    [Fact]
    public void Code_ShouldReturnCode()
    {
        // Arrange
        var error = new Error("code", "message");

        // Assert
        error.Code.ShouldBe("code");
    }

    [Fact]
    public void Message_ShouldReturnCode()
    {
        // Arrange
        var error = new Error("code", "message");

        // Assert
        error.Message.ShouldBe("message");
    }

    [Fact]
    public void ToString_ShouldReturnMessage()
    {
        // Arrange
        var error = new Error("code", "message");

        // Act
        var result = error.ToString();

        // Assert
        result.ShouldBe(error.Message);
    }

    [Fact]
    public void None_ShouldReturnNullCodeAndMessage()
    {
        var error = Error.None;

        error.Code.ShouldBe(string.Empty);
        error.Message.ShouldBe(string.Empty);
    }
}
