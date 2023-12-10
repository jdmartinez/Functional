namespace Functional;

public static partial class OptionExtensions
{
    public static Option<TReturn> Select<T, TReturn>(this Option<T> opt, Func<T, TReturn> selector)
        => opt.Map(selector);
}
