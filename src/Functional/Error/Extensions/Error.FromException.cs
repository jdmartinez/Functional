namespace Functional;

public static partial  class ErrorExtensions
{
    public static Error ToError(this Exception ex)
        => new(ex.GetBaseException().GetType().Name, ex.Message);
}
