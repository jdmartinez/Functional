namespace Functional;

public readonly partial record struct Result<T>
{
    private readonly T _value = default!;

    public readonly bool IsSuccess { get; } = true;

    public readonly bool IsFailure => !IsSuccess;

    public readonly T Value => IsSuccess ? _value : throw new InvalidOperationException();

    public readonly IEnumerable<Error> Errors { get; } = [];

    private Result(T value) => _value = value;

    private Result(IEnumerable<Error> errors)
    {
        var cleanedErrors = errors
            .Where(e => e != Error.None)
            .ToArray();

        if (cleanedErrors.Length == 0)
            throw new ArgumentException("Invalid error", nameof(errors));

        IsSuccess = false;
        Errors = cleanedErrors;
    }

    public static Result<T> Success(T value) => new(value);

    public static Result<T> Failure(IEnumerable<Error> errors) => new(errors);

    public static implicit operator Result<T>(T value) => Success(value);

    public static implicit operator Result<T>(Error error) => Failure([error]);
}
