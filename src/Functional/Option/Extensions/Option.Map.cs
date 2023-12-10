namespace Functional;

public static partial class OptionExtensions
{
    public static Option<TReturn> Map<T, TReturn>(this Option<T> opt, Func<T, TReturn> selector)
        => opt.Match(
            v => selector(v),
            () => Option<TReturn>.None
        );
}
