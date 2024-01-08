namespace Functional;

public static partial class ResultExtensions
{
    public static TReturn Match<T, TReturn>(this Result<T> result, Func<T, TReturn> onSuccess, Func<Error, TReturn> onFailure)
        => result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Error);

    public static async Task<TReturn> Match<T, TReturn>(this Result<T> result, Func<T, Task<TReturn>> onSuccess, Func<Error, Task<TReturn>> onFailure)
        => result.IsSuccess
            ? await onSuccess(result.Value)
            : await onFailure(result.Error);
}
