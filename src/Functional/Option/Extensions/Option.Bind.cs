namespace Functional;

public static partial class OptionExtensions
{
    public static Option<TReturn> Bind<T, TReturn>(this Option<T> opt, Func<T, Option<TReturn>> selector)
        => opt.Match(
            v => selector(v),
            () => Option<TReturn>.None
        );

    public static async Task<Option<TReturn>> Bind<T, TReturn>(this Option<T> opt, Func<T, Task<Option<TReturn>>> selector)
        => opt.Match(
            v => await selector(v),
            () => Option<TReturn>.None
        );
}
