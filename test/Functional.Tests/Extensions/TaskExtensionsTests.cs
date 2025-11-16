using System;
using Shouldly;

namespace Functional.Tests;

public class TaskExtensionsTests
{
    [Fact]
    public void AsTask_ShouldReturnTask_FromValue()
    {
        var task = 7.AsTask();

        task.ShouldBeAssignableTo<Task>();
    }
}
