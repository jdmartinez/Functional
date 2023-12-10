namespace Functional;

public record Error(int Code = 0, string Message = "") : GenericError
{
    public static readonly Error None = new();

    public override int Code { get; init ; } = Code;

    public override string Message { get; init ; } = Message;
}
