namespace Functional;

public readonly partial record struct Result
{
    public bool IsSuccess { get; } = true;

    public readonly bool IsFailure => !IsSuccess;

    public Error Error { get; } = Error.None;

    private Result(bool isSuccess, Error error)
    {
        if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result Failure(string errorMessage) => Failure(new Error { Message = errorMessage });

    public static Result<T> Success<T>(T value) => Result<T>.Success(value);

    public static Result<T> Failure<T>(Error error) => Result<T>.Failure(error);

}
