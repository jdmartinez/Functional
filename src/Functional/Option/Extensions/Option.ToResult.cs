namespace Functional;

public static partial class OptionExtensions
{
    public static Result<T> ToResult<T>(this Option<T> opt, Error error)
        => opt.Match(
            v => Result.Success(v),
            () => Result<T>.Failure(error)
        );
}
