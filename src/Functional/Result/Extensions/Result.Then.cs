namespace Functional;

public static partial class ResultExtensions
{
    public static Result<T> Then<T>(this Result<T> result, Action<Result<T>> action)
    {
        action(result);
        return result;
    }
}
