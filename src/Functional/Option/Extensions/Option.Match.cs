namespace Functional;

public static partial class OptionExtensions
{
    public static TReturn Match<T, TReturn>(this Option<T> opt, Func<T, TReturn> some, Func<TReturn> none)
        => opt.HasValue 
            ? some(opt.Value) 
            : none();

    public static async Task<TReturn> Match<T, TReturn>(this Option<T> opt, Func<T, Task<TReturn>> some, Func<Task<TReturn>> none)
        => opt.HasValue
            ? await some(opt.Value)
            : await none();
}
