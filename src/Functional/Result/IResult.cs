namespace Functional;

public interface IResult
{
    bool IsSuccess { get; }

    bool IsFailure { get; }

    Error Error { get; }
}

public interface IValue<out T>
{
    T Value { get; }
}

public interface IResult<out T> : IResult, IValue<T>
{ }
