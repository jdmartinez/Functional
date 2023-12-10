namespace Functional;

public abstract record GenericError
{
    public virtual int Code { get; init; } = 0;

    public virtual string Message { get; init; } = string.Empty;

    public override string ToString() => Message;

}