namespace Functional;

public static partial class ResultExtensions
{
    public static Result Tap(this Result result, Action action)
    {
        if (result.IsSuccess) action();

        return result;
    }

    public static Result<T> Tap<T>(this Result<T> result, Action action)
    {
        if (result.IsSuccess) action();

        return result;
    }

    public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
    {
        if (result.IsSuccess) action(result.Value);

        return result;
    }
}
