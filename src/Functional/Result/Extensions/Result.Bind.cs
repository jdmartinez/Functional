namespace Functional;

public static partial class ResultExtensions
{
    public static Result<TReturn> Bind<T, TReturn>(this Result<T> result, Func<T, Result<TReturn>> func)
        => result.Match(
            func,
            Result.Failure<TReturn>
        );
}
