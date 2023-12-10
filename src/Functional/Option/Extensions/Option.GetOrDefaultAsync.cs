namespace Functional;

public static partial class OptionExtensions
{
    public static Task<T> GetOrDefaultAsync<T, TReturn>(this Option<T> opt, Func<Task<T>> defaultValue)
        => opt.Match(
            v => Task.FromResult(v),
            () => defaultValue()
        );

}
