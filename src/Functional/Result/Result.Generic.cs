namespace Functional;

public readonly partial record struct Result<T> : IResult<T>
{
    private readonly T _value = default!;

    public readonly bool IsSuccess { get; } = true;

    public readonly bool IsFailure => !IsSuccess;

    public readonly T Value => IsSuccess ? _value : throw new InvalidOperationException(nameof(Value));

    public readonly Error Error { get; } = Error.None;

    private Result(T value) => _value = value;

    private Result(Error error)
    {
        if (error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = false;
        Error = error;
    }

    public static Result<T> Success(T value) => new(value);

    public static Result<T> Failure(Error error) => new(error);

    public static implicit operator Result<T>(T value)
        => value is IResult<T> result
            ? result.IsSuccess
                ? Success(result.Value)
                : Failure(result.Error)
            : Success(value);

    public static implicit operator Result(Result<T> result)
        => result.IsSuccess
            ? Result.Success()
            : Result.Failure();

    public static implicit operator Result<T>(Error error) => Failure(error);
}
