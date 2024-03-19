namespace Functional;

public static partial class ResultExtensions
{
    public static T GetOrDefault<T>(this Result<T> result, T defaultValue)
        => result.IsSuccess
            ? result.Value
            : defaultValue;

    public static T GetOrDefault<T>(this Result<T> result, Func<T> defaultValue)
        => result.IsSuccess
            ? result.Value
            : defaultValue();
}
