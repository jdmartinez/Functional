namespace Functional;

public readonly partial record struct Error(string Code = "", string Message = "")
{
    public static readonly Error None = new();

    public override string ToString() => Message;
}
