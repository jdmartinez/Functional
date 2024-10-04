namespace Functional;

public readonly partial record struct Error
{
    public string Code { get; init; } = string.Empty;

    public string Message { get; init; } = string.Empty;

    public static readonly Error None = new(string.Empty, string.Empty);

    public Error() : this(string.Empty, string.Empty)
    { }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public override string ToString() => Message;
}
