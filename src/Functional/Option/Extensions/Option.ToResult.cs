namespace Functional;

public static partial class OptionExtensions
{
    public static Result<T> ToResult<T>(this Option<T> opt, Error error)
    {
        if (opt.IsSome) return Result.Success(opt.Value);

        return Result.Failure<T>(error);
    }
}
