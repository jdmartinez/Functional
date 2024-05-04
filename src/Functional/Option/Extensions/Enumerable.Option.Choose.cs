namespace Functional;

public static partial class OptionExtensions
{
    public static IEnumerable<T> Choose<T>(this IEnumerable<Option<T>> options)
        => options
            .Where(opt => opt.HasValue)
            .Select(opt => opt.Value);
}
