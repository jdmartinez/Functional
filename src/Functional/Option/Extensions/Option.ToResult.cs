namespace Functional;

public static partial class OptionExtensions
{
    public static Result<T> ToResult<T>(this Option<T> opt, Error error)
    {
        if (!opt.HasValue) return Result<T>.Failure(error);

        return Result.Success(opt.Value);
    }
}
