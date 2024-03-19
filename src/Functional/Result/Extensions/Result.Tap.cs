namespace Functional;

public static partial class ResultExtensions
{
    public static Result<T> Tap<T>(this Result<T> result, Action action)
        => result.Match(
            r => { action(); return r; },
            _ => result
        );

    public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
        => result.Match(
            r => { action(r); return r; },
            _ => result
        );

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
