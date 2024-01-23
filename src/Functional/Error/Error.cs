namespace Functional;

public record Error(int Code = 0, string Message = "")
{
    public static readonly Error None = new();

    public override string ToString() => Message;
}
