namespace SumTypes;

public class Option<T>
{
    private readonly int _index;
    private readonly T? _value;

    private Option(int index)
    {
        _index = index;
        _value = default;
    }

    private Option(T value)
    {
        _index = 0;
        _value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TResult Match<TResult>(Func<T, TResult> f, Func<TResult> defaultFunc) =>
        _index switch
        {
            0 => f(_value!),
            -1 => defaultFunc(),
            _ => throw new InvalidOperationException()
        };
    
    public Option<TResult> Map<TResult>(Func<T, TResult> f) => 
        _index switch
        {
            0 => f(_value!),
            -1 => None<TResult>(),
            _ => throw new InvalidOperationException()
        };

    public Option<T> Do(Action<T> f, Action noneFunc)
    {
        switch (_index)
        {
            case 0:
                f(_value!);
                return this;
            case -1:
                noneFunc();
                return this;
            default:
                throw new InvalidOperationException();
        }
    }

    public static implicit operator Option<T>(T t) => new(t);
    public static Option<TResult> None<TResult>() => new(-1);
}