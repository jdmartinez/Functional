namespace Functional;

public static partial class OptionExtensions
{
    public static Option<TReturn> Bind<T, TReturn>(this Option<T> opt, Func<T, Option<TReturn>> selector)
        => opt.Match(
            v => selector(v),
            () => Option<TReturn>.None
        );
}
