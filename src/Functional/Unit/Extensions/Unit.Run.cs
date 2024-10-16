namespace Functional;

public static partial class UnitExtensions
{
    public static Unit Run(this Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        action();
        return Unit.Default;
    }

    public static Unit Run<T>(this Action<T> action, T arg)
    {
        ArgumentNullException.ThrowIfNull(action);

        action(arg);
        return Unit.Default;
    }

    public static Unit Run<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
    {
        ArgumentNullException.ThrowIfNull(action);

        action(arg1, arg2);
        return Unit.Default;
    }

    public static Unit Run<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
    {
        ArgumentNullException.ThrowIfNull(action);

        action(arg1, arg2, arg3);
        return Unit.Default;
    }
}
