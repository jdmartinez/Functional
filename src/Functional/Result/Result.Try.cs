namespace Functional;

public readonly partial record struct Result
{
    public static async Task<Result<T>> Try<T>(Func<Task<T>> task)
    {
        try
        {
            return Success(await task());
        }
        catch (Exception ex)
        {
            return Failure<T>(ex.ToError());
        }
    }
}
