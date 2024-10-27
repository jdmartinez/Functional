namespace Functional;

public static partial class ValidationResultExtensions
{
    public static TReturn Match<T, TReturn>(this ValidationResult<T> result, Func<TReturn> onSuccess, Func<TReturn> onFailure)
        => result.IsSuccess
            ? onSuccess()
            : onFailure();

    public static TReturn Match<T, TReturn>(this ValidationResult<T> result, Func<T, TReturn> onSuccess, Func<IEnumerable<Error>, TReturn> onFailure)
        => result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
}
