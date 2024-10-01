namespace Functional;

public static partial class OptionExtensions
{
    public static T Reduce<T>(this Option<T> opt, T defaultValue) => opt.Match(v => v, () => defaultValue);

    public static T Reduce<T>(this Option<T> opt, Func<T> defaultValue) => opt.Match(v => v, () => defaultValue());

    public static Option<T> Reduce<T>(this Option<T> opt, Option<T> defaultValue)
        => opt.Match(
            _ => opt,
            () => defaultValue
        );

    public static Option<T> Reduce<T>(this Option<T> opt, Func<Option<T>> defaultValue)
        => opt.Match(
            _ => opt,
            () => defaultValue()
        );

    public static TReturn Reduce<T, TReturn>(this Option<T> opt, Func<T, TReturn> selector, TReturn defaultValue)
        => opt.Match(
            v => selector(v),
            () => defaultValue
        );
}
