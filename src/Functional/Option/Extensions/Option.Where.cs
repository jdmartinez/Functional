namespace Functional;

public static partial class OptionExtensions
{
    public static Option<T> Where<T>(this Option<T> opt, Func<T, bool> predicate)
        => opt.Match(
            v => predicate(v) ? opt : Option<T>.None,
            () => Option<T>.None
        );
}
