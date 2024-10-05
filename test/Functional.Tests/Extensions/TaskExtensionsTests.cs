using System;
using FluentAssertions;

namespace Functional.Tests;

public class TaskExtensionsTests
{
    [Fact]
    public void AsTask_ShouldReturnTask_FromValue()
    {
        var task = 7.AsTask();

        task.Should().BeAssignableTo<Task>();
    }
}
