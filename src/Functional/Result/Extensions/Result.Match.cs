namespace Functional;

public static partial class ResultExtensions
{
    public static TReturn Match<T, TReturn>(this Result<T> result, Func<T, TReturn> onSuccess, Func<Error, TReturn> onFailure)
        => result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Error);
}
