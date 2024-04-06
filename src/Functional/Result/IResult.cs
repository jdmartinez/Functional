namespace Functional;

public interface IResult
{
    bool IsSuccess { get; }

    bool IsFailure { get; }
}
