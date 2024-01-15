namespace Functional;

public static class TaskExtensions
{
    public static Task<T> AsTask<T>(this T value) => Task.FromResult(value);
}
