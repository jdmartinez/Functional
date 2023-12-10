namespace Functional;

public readonly record struct Option
{
    public static Option None => new();

    public static Option<T> From<T>(T value) => Option<T>.From(value);
}

public readonly record struct Option<T> : IOption<T>
{
    private readonly bool _hasValue;
    private readonly T _value;

    public T Value => !_hasValue ? throw new InvalidOperationException(nameof(Value)) : _value;

    public static Option<T> None => new();

    public bool HasValue => _hasValue;

    private Option(T value)
    {
        if (value is null)
        {
            _hasValue = false;
            _value = default!;
            return;
        }

        _hasValue = true;
        _value = value;
    }

    public override int GetHashCode() => HasValue ? Value!.GetHashCode() * 43 : 0;

    public override string ToString() => Value?.ToString() ?? "(No value)";

    public static Option<T> From(T value) => new(value);

    public static implicit operator Option<T>(Option value) => None;

    public static implicit operator Option<T>(T value)
    {
        if (value is Option<T>) return value;

        return From(value);
    }


}
