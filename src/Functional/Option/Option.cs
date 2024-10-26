namespace Functional;

public readonly record struct Option
{
    public static Option None => new();

    public static Option<T> Some<T>(T value) => Option<T>.Some(value);
}

public readonly partial record struct Option<T>
{
    private readonly T? _value = default;

    public T Value => _value ?? throw new InvalidOperationException(nameof(Value));

    public static Option<T> None => default;

    public bool IsSome { get; }

    private Option(T? value)
    {
        _value = value ?? default;
        IsSome = value is not null;
    }

    public override int GetHashCode() => (_value?.GetHashCode() ?? 0) * 43;

    public override string ToString() => Value?.ToString() ?? "(No value)";

    public static Option<T> Some(T value) => new(value);

    public static implicit operator Option<T>(Option _) => None;

    public static implicit operator Option<T>(T? value)
        => value switch
        {
            Option<T> opt => opt,
            not null => Some(value),
            _ => None
        };
}
