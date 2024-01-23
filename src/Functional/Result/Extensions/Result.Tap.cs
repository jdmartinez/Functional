namespace Functional;

public static partial class ResultExtensions
{
    public static Result<T> Tap<T>(this Result<T> result, Action action)
        => result.Match(
            r => { action(); return r; },
            Result<T>.Failure
        );

    public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
        => result.Match(
            r => { action(r); return r; },
            Result<T>.Failure
        );
}
