namespace Functional;

public static partial class OptionExtensions
{
    public static Option<T> Or<T>(this Option<T> opt, Option<T> fallback)
        => opt.Match(
            _ => opt,
            () => fallback
        );

    public static Option<T> Or<T>(this Option<T> opt, Func<T> fallback)
        => opt.Match(
            _ => opt,
            () => fallback()
        );    

    public static Option<T> Or<T>(this Option<T> opt, Func<Option<T>> fallback)
        => opt.Match(
            _ => opt,
            () => fallback()
        );

    public static async Task<Option<T>> Or<T>(this Option<T> opt, Func<Task<T>> fallback)
        => await opt.MatchAsync(
            _ => opt,
            () => await fallback()
        );

    public static async Task<Option<T>> Or<T>(this Option<T> opt, Func<Task<Option<T>>> fallback)
        => await opt.MatchAsync(
            _ => opt,
            () => await fallback()
        );

}
