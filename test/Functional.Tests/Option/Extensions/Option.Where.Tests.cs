using FluentAssertions;

namespace Functional.Tests;

public partial class OptionExtensionsTests
{
    [Fact]
    public void Where_ShouldReturnOption_WhenConditionIsPassed()
    {
        var opt = Option.Some(3);

        var result = opt.Where(v => v == 3);

        result.IsSome.Should().BeTrue();
        result.Should().Be(opt);
    }

    [Fact]
    public void Where_ShouldReturnOptionNone_WhenConditionNotPass()
    {
        var opt = Option.Some(3);

        var result = opt.Where(v => v > 3);

        result.IsSome.Should().BeFalse();
    }

    [Fact]
    public void Where_ShouldReturnOptionNone_WhenOptionIsNone()
    {
        var opt = Option<int>.None;

        var result = opt.Where(v => v > 3);

        result.IsSome.Should().BeFalse();
    }
}
