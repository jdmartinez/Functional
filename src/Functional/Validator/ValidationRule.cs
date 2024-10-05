using System;
using System.Linq.Expressions;

namespace Functional;

public class ValidationRule<T, TProp> : IValidationRule<T>
{
    private readonly Expression<Func<T, TProp>> _projection;
    private readonly Func<TProp, bool> _predicate;
    private readonly string _errorMessage;

    public Error Error { get; private set; } = Error.None;

    public ValidationRule(Expression<Func<T, TProp>> projection, Func<TProp, bool> predicate, string errorMessage)
    {
        _projection = projection;
        _predicate = predicate;
        _errorMessage = errorMessage;
    }

    public bool Validate(T value)
    {
        var result = _predicate(_projection.Compile()(value));

        if (!result) Error = new(GetPropertyName(_projection), _errorMessage);

        return result;
    }

    private static string GetPropertyName(Expression<Func<T, TProp>> expression)
        => expression.Body is MemberExpression memberExpression
            ? memberExpression.Member.Name
            : string.Empty;
}
