namespace Functional;

public static partial class ResultExtensions
{
    public static Result Tap(Result result, Action action)
    {
        if (result.IsSuccess) action();

        return result;
    }

    public static async Task<Result> Tap(Result result, Func<Task> func)
    {
        if (result.IsSuccess)
            await func();

        return result;
    }

    public static Result<T> Tap<T>(this Result<T> result, Action action)
    {
        if (result.IsSuccess) action();

        return result;
    }

    public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
    {
        if (result.IsSuccess)
            action(result.Value);

        return result;
    }

    public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<Task> func)
    {
        if (result.IsSuccess)
            await func();

        return result;
    }

    public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<T, Task> func)
    {
        var result = await resultTask;

        if (result.IsSuccess)
            await func(result.Value);

        return result;
    }
}
