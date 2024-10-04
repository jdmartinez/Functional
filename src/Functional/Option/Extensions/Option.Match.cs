namespace Functional;

public static partial class OptionExtensions
{
    public static TReturn Match<T, TReturn>(this Option<T> opt, Func<T, TReturn> some, Func<TReturn> none)
        => opt.IsSome
            ? some(opt.Value)
            : none();

}
