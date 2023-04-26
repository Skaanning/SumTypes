namespace SumTypes.Results;

public class UnitResult<TError> : Result<Unit, TError>
{
    protected UnitResult(Unit value) : base(value)
    {
    }

    
    protected UnitResult(TError errorResult) : base(errorResult)
    {
    }

    public static Unit Ok => Unit.Instance;
    public static implicit operator UnitResult<TError>(TError t) => new(t);
    public static implicit operator UnitResult<TError>(Unit u) => new(u);
}