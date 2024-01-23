namespace Functional;

public static partial class OptionExtensions
{
    public static Option<T> ToOption<T>(this T? value) where T : class
        => value is not null
            ? value
            : Option<T>.None;
}
