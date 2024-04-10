namespace Functional;

public static partial class ResultExtensions
{
    public static Result<TReturn> Map<TReturn>(this Result result, Func<TReturn> func)
        => result.IsSuccess
            ? Result.Success(func())
            : Result.Failure<TReturn>(Error.None);

    public static Result<TReturn> Map<T, TReturn>(this Result<T> result, Func<T, TReturn> func)
        => result.IsSuccess
            ? Result.Success(func(result.Value))
            : Result.Failure<TReturn>(result.Error);

    public static Result Map<T>(this Result<T> result, Func<T, Result> func)
        => result.IsSuccess
            ? func(result.Value)
            : Result.Failure();
}
