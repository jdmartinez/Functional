namespace Functional;

public static partial class OptionExtensions
{
    public static T GetOrDefault<T>(this Option<T> opt, T defaultValue) => opt.Match(v => v, () => defaultValue);

    public static T GetOrDefault<T>(this Option<T> opt, Func<T> defaultValue) => opt.Match(v => v, () => defaultValue());

    public static Option<T> GetOrDefault<T>(this Option<T> opt, Option<T> defaultValue)
        => opt.Match(
            _ => opt,
            () => defaultValue
        );

    public static Option<T> GetOrDefault<T>(this Option<T> opt, Func<Option<T>> defaultValue)
        => opt.Match(
            _ => opt,
            () => defaultValue()
        );

    public static TReturn GetOrDefault<T, TReturn>(this Option<T> opt, Func<T, TReturn> selector, TReturn defaultValue)
        => opt.Match(
            v => selector(v),
            () => defaultValue
        );
}
