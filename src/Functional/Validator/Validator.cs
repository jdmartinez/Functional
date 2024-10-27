using System.Linq.Expressions;

namespace Functional;

public static class Validator
{
    public static Validator<T> Of<T>(T value) => Validator<T>.Of(value);
}

public sealed class Validator<T>
{
    public T Value { get; }

    private readonly List<IValidationRule<T>> _rules = [];

    private Validator(T value) => Value = value;

    public static Validator<T> Of(T value) => new(value);

    public Validator<T> Ensure<TProp>(Expression<Func<T, TProp>> projection, Func<TProp, bool> predicate, string errorMessage)
        => Ensure<TProp>(new ValidationRule<T, TProp>(projection, predicate, errorMessage));

    private Validator<T> Ensure<TProp>(IValidationRule<T> rule)
    {
        _rules.Add(rule);
        return this;
    }

    public ValidationResult<T> Validate()
    {
        var failureRules = _rules
            .Where(r => !r.Validate(Value))
            .Select(e => e.Error);

        return failureRules.Any()
            ? ValidationResult<T>.Failure(Value, failureRules)
            : Value;
    }
}
