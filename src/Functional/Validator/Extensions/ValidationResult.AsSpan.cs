namespace Functional;

public static partial class ValidationResultExtensions
{
    public static ReadOnlySpan<Error> AsSpan<T>(this ValidationResult<T> result)
        => result.IsSuccess
            ? []
            : new(result.Errors.ToArray());
}
