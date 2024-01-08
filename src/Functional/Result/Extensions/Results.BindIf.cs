namespace Functional;

public static partial class ResultExtensions
{
    public static Result<T> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<T>> func)
    {
        if (!result.IsSuccess || !predicate(result.Value))
        {
            return result;
        }

        return result.Bind(func);
    }
}
