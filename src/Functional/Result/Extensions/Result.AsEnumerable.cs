namespace Functional;

public static partial class ResultExtensions
{
    public static IEnumerable<T> AsEnumerable<T>(this Result<T> result)
    {
        if (result.IsSuccess) yield return result.Value;
    }
}
