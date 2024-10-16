namespace Functional;

public readonly record struct Unit
{
    public static readonly Unit Default = new();

    public override int GetHashCode() => 0;

    public override string ToString() => "Unit:()";
}
