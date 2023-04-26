
namespace SumTypes.Results;

public class Result<T, TError>
{
    public bool IsSuccess { get; }
    
    private readonly T? _value;
    private readonly TError? _error;
    
    protected Result(T value) 
    {
        IsSuccess = true;
        _value = value ?? throw new ArgumentNullException($"{nameof(value)}");
        _error = default;
    }
    
    protected Result(TError errorResult)
    {
        if (errorResult is null)
            throw new ArgumentNullException($"{nameof(errorResult)}");
        
        IsSuccess = false;
        _value = default;
        _error = errorResult;
    }
    
    public TResult Match<TResult>(Func<T, TResult> valueFunction, Func<TError, TResult> errorFunction) =>
        IsSuccess switch
        {
            true => valueFunction(_value!),
            false => errorFunction(_error!)
        };
    
    public Result<TResult, TErrorResult> Map<TResult, TErrorResult>(Func<T, TResult> valueFunction, Func<TError, TErrorResult> errorFunction) => 
        IsSuccess switch
        {
            true => valueFunction(_value!),
            false => errorFunction(_error!)
        };

    public Result<T, TError> Do(Action<T> valueFunction, Action<TError> errorFunction)
    {
        switch (IsSuccess)
        {
            case true:
                valueFunction(_value!);
                return this;
            case false:
                errorFunction(_error!);
                return this;
        }
    }
    
    public static implicit operator Result<T, TError>(TError t) => new(t);
    public static implicit operator Result<T, TError>(T t) => new(t);
}
