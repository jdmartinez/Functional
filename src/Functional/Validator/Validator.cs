namespace Functional;

public sealed class Validator<T>
{
    private record ValidationRule(
        Func<T, object> Projection,
        Func<object, bool> Predicate,
        string ErrorMessage
    );

    private readonly T _value = default!;
    private readonly List<ValidationRule> _rules = [];

    private Validator(T value) => _value = value;

    public static Validator<T> Of(T value) => new(value);

    public Validator<T> WithRule(Func<T, object> projection, Func<object, bool> predicate, string errorMessage)
    {
        _rules.Add(new ValidationRule(projection, predicate, errorMessage));

        return this;
    }

    public Result<T> Validate()
    {
        var failureRules = _rules
            .Where(r => !r.Predicate(r.Projection(_value)))
            .Select(r => r);

        if (!failureRules.Any()) return Result.Success(_value);

        return Result<T>.Failure(failureRules.Select(r => Validator<T>.ToError(r)).FirstOrDefault());
    }

    private static Error ToError(ValidationRule validationRule)
        => string.IsNullOrEmpty(validationRule.ErrorMessage)
            ? Error.None
            : new Error(validationRule.ErrorMessage);
}
