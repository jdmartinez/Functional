namespace Functional;

public static partial class ResultExtensions
{
    public static T GetValueOrDefault<T>(this Result<T> result, T defaultValue)
        => result.IsSuccess
            ? result.Value
            : defaultValue;

    public static T GetValueOrDefault<T>(this Result<T> result, Func<T> defaultValue)
        => result.IsSuccess
            ? result.Value
            : defaultValue();

    public static Task<T> GetValueOrDefault<T>(this Result<T> result, Task<T> defaultValue)
        => result.IsSuccess
            ? result.Value
            : defaultValue;

    public static async Task<T> GetValueOrDefault<T>(this Result<T> result, Func<Task<T>> defaultValue)
        => result.IsSuccess
            ? result.Value
            : await defaultValue();
}
