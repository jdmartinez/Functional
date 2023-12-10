namespace Functional;

public static partial class OptionExtensions
{
    public static Option<TReturn> SelectMany<T, TReturn>(this Option<T> opt, Func<T, Option<TReturn>> selector)
        => opt.Bind(selector);

    public static Option<TResult> SelectMany<T, TReturn, TResult>(
        this Option<T> opt,
        Func<T, Option<TReturn>> selector,
        Func<T, TReturn, TResult> projector)
            => opt.Match(
                v => selector(v).Match(
                        r => projector(v, r),
                        () => Option<TResult>.None
                    ),
                () => Option<TResult>.None
            );
}
