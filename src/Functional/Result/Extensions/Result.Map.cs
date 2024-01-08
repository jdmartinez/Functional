namespace Functional;

public static partial class ResultExtensions
{
    public static Result<TReturn> Map<T, TReturn>(this Result<T> result, Func<T, TReturn> func)
        => result.Match(
            v => Result.Success(func(v)),
            Result.Failure<TReturn>
        );

    public static Task<TReturn> Map<T, TReturn>(this Result<T> result, Func<T, Task<TReturn>> func)
        => result.Match(
            v => Result.Success(func(v)),
            Result.Failure<TReturn>
        );
}
