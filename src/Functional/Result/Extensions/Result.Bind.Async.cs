namespace Functional;

public static partial class ResultExtensions
{
    public static async Task<Result<TReturn>> Bind<T, TReturn>(this Task<Result<T>> resultTask, Func<T, Task<Result<TReturn>>> func)
    {
        var result = await resultTask;
        
        if (result.IsFailure) return Result.Failure<TReturn>(result.Error);
        
        return await func(result.Value);
    }
}
