using Shouldly;

namespace Functional.Tests;

public partial class UnitExtensionsTests
{
    [Fact]
    public void Return_ShouldRunActionAndReturnUnit_WhenActionHasNoArguments()
    {
        var test = string.Empty;
        Action action = () => test = "test";

        var unit = action.Run();

        unit.ShouldBe(Unit.Default);
        test.ShouldBe("test");
    }

    [Fact]
    public void Return_ShouldRunActionAndReturnUnit_WhenActionHasOneArgument()
    {
        var arg = string.Empty;
        Action<string> action = t => arg = t;

        var unit = action.Run("test");

        unit.ShouldBe(Unit.Default);
        arg.ShouldBe("test");
    }

    [Fact]
    public void Return_ShouldRunActionAndReturnUnit_WhenActionHasTwoArguments()
    {
        var arg1 = "test";
        var arg2 = string.Empty;
        Action<string, string> action = (t1, t2) => arg2 = t1;

        var unit = action.Run(arg1, arg2);

        unit.ShouldBe(Unit.Default);
        arg2.ShouldBe(arg1);
    }

    [Fact]
    public void Return_ShouldRunActionAndReturnUnit_WhenActionHasThreeArguments()
    {
        var arg1 = "test";
        var arg2 = "test2";
        var arg3 = string.Empty;
        Action<string, string, string> action = (t1, t2, t3) => arg3 = $"{arg1}+{arg2}";

        var unit = action.Run(arg1, arg2, arg3);

        unit.ShouldBe(Unit.Default);
        arg3.ShouldBe($"{arg1}+{arg2}");
    }
}
