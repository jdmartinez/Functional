namespace Functional;

public static partial class OptionExtensions
{
    public static IEnumerable<T> AsEnumerable<T>(this Option<T> opt)
    {
        if (opt.IsSome) yield return opt.Value;
    }
}
