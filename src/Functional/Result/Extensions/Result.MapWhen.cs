using System.Collections.Concurrent;

namespace Functional;

public static partial class ResultExtensions
{
    public static Result<T> MapWhen<T>(this Result<T> result, Func<T, bool> predicate, Func<T, T> func)
    {
        if (!result.IsSuccess || !predicate(result.Value))
        {
            return result;
        }

        return result.Map(func);
    }
}
