namespace Functional;

public static partial class OptionExtensions
{
    public static Option<T> Or<T>(this Option<T> opt, Option<T> fallback)
    {
        if (!opt.HasValue) return fallback;

        return opt;
    }

    public static Option<T> Or<T>(this Option<T> opt, Func<T> fallback)
    {
        if (!opt.HasValue) return fallback();

        return opt;
    }

    public static Option<T> Or<T>(this Option<T> opt, Func<Option<T>> fallback)
    {
        if (!opt.HasValue) return fallback();

        return opt;
    }

}
