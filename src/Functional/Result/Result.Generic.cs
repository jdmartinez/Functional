namespace Functional;

public readonly partial record struct Result<T> : IResult<T>
{
    private readonly T _value = default!;

    public bool IsSuccess { get; } = true;

    public readonly bool IsFailure => !IsSuccess;

    public readonly T Value => IsSuccess ? _value : throw new InvalidOperationException(Error.Message);

    public Error Error { get; } = Error.None;

    private Result(T value)
    {
        IsSuccess = true;
        _value = value;
    }

    private Result(Error error)
    {
        if (error == Error.None) throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = false;
        Error = error;
    }

    public static Result<T> Success(T value) => new(value);

    public static Result<T> Failure(Error error) => new(error);

    public bool Equals(T other) => EqualityComparer<T>.Default.Equals(Value, other);

    public static implicit operator Result<T>(T value) => Success(value);

    public static implicit operator Result<T>(Error error) => Failure(error);
}
