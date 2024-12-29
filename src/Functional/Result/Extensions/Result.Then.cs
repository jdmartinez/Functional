namespace Functional;

public static partial class ResultExtensions
{
    public static Task<Result<TResult>> Then<T, TResult>(this Task<Result<T>> resultTask, Func<T, Task<Result<TResult>>> func)
        => resultTask.Bind(func);

    public static async Task<Result<TResult>> Then<T, TResult>(this Task<Result<T>> resultTask, Func<T, Task<TResult>> func)
    {
        var result = await resultTask;

        if (result.IsFailure) return Result.Failure<TResult>(result.Error);

        return await func(result.Value);
    }

    public static async Task<Result<TResult>> Then<T, TResult>(this Task<Result<T>> resultTask, Func<T, TResult> func)
    {
        var result = await resultTask;

        return result.IsFailure
         ? Result.Failure<TResult>(result.Error) 
            : func(result.Value);
    }

    public static Result<TResult> Then<T, TResult>(this Result<T> result, Func<T, Result<TResult>> func)
        => result.Bind(func);

    public static Task<Result<T>> Then<T>(this Task<Result<T>> resultTask, Func<T, Task> func)
        => resultTask.Tap(func);
}
