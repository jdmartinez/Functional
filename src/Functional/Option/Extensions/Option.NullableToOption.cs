namespace Functional;

public static partial class OptionExtensions
{
    public static Option<T> ToOption<T>(this T? value) where T : class
        => value ?? Option<T>.None;
}
