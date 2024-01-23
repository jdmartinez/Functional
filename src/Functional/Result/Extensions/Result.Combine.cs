namespace Functional;

public static partial class ResultExtensions
{
    /// <summary>
    /// Combines an enumerable of <see cref="Result{T}"/> in one
    /// </summary>
    /// <returns>A succeeded result with the list of results if none is failure.
    /// Otherwhise, a failure result with the first error found
    /// </returns>
    public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results)
    {
        var failed = results.Where(r => r.IsFailure);

        return failed.Any()
            ? Result.Failure<IEnumerable<T>>(failed.First().Errors)
            : Result.Success(results.Select(r => r.Value));
    }
}
