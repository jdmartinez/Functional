namespace Functional;

public static partial class OptionExtensions
{
    public static IEnumerable<T> AsEnumerable<T>(this Option<T> opt)
    {
        if (opt.HasValue) yield return opt.Value;

        return Enumerable.Empty<T>();
    }
}
