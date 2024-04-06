namespace Functional;

public interface IResult<out T> : IResult
{
    T Value { get; }

    Error Error { get; }
}
