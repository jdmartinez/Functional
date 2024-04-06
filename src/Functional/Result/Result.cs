namespace Functional;

public readonly partial record struct Result : IResult
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    private Result(bool isSuccess) => IsSuccess = isSuccess;

    public static Result Success() => new(true);

    public static Result Failure() => new(false);

    public static Result<T> Success<T>(T value) => Result<T>.Success(value);

    public static Result<T> Failure<T>(Error error) => Result<T>.Failure(error);
}
