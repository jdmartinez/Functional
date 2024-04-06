namespace Functional;

public static partial class ResultExtensions
{
    public static Result<TReturn> Bind<T, TReturn>(this Result<T> result, Func<T, Result<TReturn>> func)
        => result.IsSuccess
            ? func(result.Value)
            : Result.Failure<TReturn>(result.Error);

    public static Result Bind<T>(this Result<T> result, Func<T, Result> func)
        => result.IsSuccess
            ? func(result.Value)
            : result;
}
