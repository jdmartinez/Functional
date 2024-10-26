namespace Functional;

public record ValidationResult<T>
{
    private readonly List<Error> _errors = [];

    public T Value { get; } = default!;

    public IReadOnlyList<Error> Errors => _errors.AsReadOnly();

    public bool IsSuccess => _errors.Count == 0;

    public bool IsFailure => !IsSuccess;

    private ValidationResult(T value, IEnumerable<Error> errors)
    {
        Value = value;
        _errors.AddRange(errors.Where(e => e != Error.None));
    }

    public static ValidationResult<T> Success(T value) => new(value);

    public static ValidationResult<T> Failure(T value, IEnumerable<Error> errors)
    {
        if (errors.Any(e => e == Error.None))
            throw new InvalidOperationException(nameof(errors));

        return new ValidationResult<T>(value, errors);
    }

    public static implicit operator ValidationResult<T>(T value) => Success(value);

    public override int GetHashCode()
        => IsSuccess
            ? 0
            : HashCode.Combine(_errors);
}
