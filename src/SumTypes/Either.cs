namespace SumTypes;

/// <summary>
/// C# version of a discriminated union like seen in F# or haskell.<br/>
/// The value will be either of type T0 or type T1. Null values are not allowed and will throw an ArgumentNullException
/// </summary>
public readonly struct Either<T0, T1>
{
    private readonly int _index;
    private readonly T0? _value0;
    private readonly T1? _value1;

    private Either(T0 value0)
    {
        _index = 0;
        _value0 = value0 ?? throw new ArgumentNullException(nameof(value0));
        _value1 = default;
    }

    private Either(T1 value1)
    {
        _index = 1;
        _value0 = default;
        _value1 = value1 ?? throw new ArgumentNullException(nameof(value1));
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1) =>
        _index switch
        {
            0 => f0(_value0!),
            1 => f1(_value1!),
            _ => throw new InvalidOperationException()
        };
    
    public Either<TResult0, TResult1> Map<TResult0, TResult1>(Func<T0, TResult0> f0, Func<T1, TResult1> f1) => 
        _index switch
        {
            0 => f0(_value0!),
            1 => f1(_value1!),
            _ => throw new InvalidOperationException()
        };

    public Either<T0, T1> Do(Action<T0> f0, Action<T1> f1)
    {
        switch (_index)
        {
            case 0:
                f0(_value0!);
                return this;
            case 1:
                f1(_value1!);
                return this;
            default:
                throw new InvalidOperationException();
        }
    }

    public static implicit operator Either<T0, T1>(T0 t) => new(t);
    public static implicit operator Either<T0, T1>(T1 t) => new(t);
}

/// <summary>
/// C# version of a discriminated union like seen in F# or haskell.<br/>
/// The value will be either of type T0, T1 or T2. Null values are not allowed and will throw an ArgumentNullException
/// </summary>
public readonly struct Either<T0, T1, T2>
{
    private readonly int _index;
    private readonly T0? _value0;
    private readonly T1? _value1;
    private readonly T2? _value2;

    private Either(T0? value0)
    {
        _index = 0;
        _value0 = value0 ?? throw new ArgumentNullException(nameof(value0));
        _value1 = default;
        _value2 = default;
    }

    private Either(T1 value1)
    {
        _index = 1;
        _value0 = default;
        _value1 = value1 ?? throw new ArgumentNullException(nameof(value1));
        _value2 = default;
    }

    private Either(T2 value2)
    {
        _index = 2;
        _value0 = default;
        _value1 = default;
        _value2 = value2 ?? throw new ArgumentNullException(nameof(value2));
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2) =>
        _index switch
        {
            0 => f0(_value0!),
            1 => f1(_value1!),
            2 => f2(_value2!),
            _ => throw new InvalidOperationException()
        };
    
    public Either<TResult0, TResult1, TResult2> Map<TResult0, TResult1, TResult2>(Func<T0, TResult0> f0, Func<T1, TResult1> f1, Func<T2, TResult2> f2) => 
        _index switch
        {
            0 => f0(_value0!),
            1 => f1(_value1!),
            2 => f2(_value2!),
            _ => throw new InvalidOperationException()
        };

    public Either<T0, T1, T2> Do(Action<T0> f0, Action<T1> f1, Action<T2> f2)
    {
        switch (_index)
        {
            case 0:
                f0(_value0!);
                return this;
            case 1:
                f1(_value1!);
                return this;
            case 2:
                f2(_value2!);
                return this;
            default:
                throw new InvalidOperationException();
        }
    }

    public static implicit operator Either<T0, T1, T2>(T0 t0) => new(t0);
    public static implicit operator Either<T0, T1, T2>(T1 t1) => new(t1);
    public static implicit operator Either<T0, T1, T2>(T2 t2) => new(t2);
}

/// <summary>
/// C# version of a discriminated union like seen in F# or haskell.<br/>
/// The value will be either of type T0, T1, T2 or T3. Null values are not allowed and will throw an ArgumentNullException
/// </summary>
public readonly struct Either<T0, T1, T2, T3>
{
    private readonly int _index;
    private readonly T0? _value0;
    private readonly T1? _value1;
    private readonly T2? _value2;
    private readonly T3? _value3;

    private Either(T0 value0)
    {
        _index = 0;
        _value0 = value0 ?? throw new ArgumentNullException($"{nameof(value0)}");
        _value1 = default;
        _value2 = default;
        _value3 = default;
    }

    private Either(T1 value1)
    {
        _index = 1;
        _value0 = default;
        _value1 = value1 ?? throw new ArgumentNullException(nameof(value1));
        _value2 = default;
        _value3 = default;
    }

    private Either(T2 value2)
    {
        _index = 2;
        _value0 = default;
        _value1 = default;
        _value2 = value2 ?? throw new ArgumentNullException($"{nameof(value2)}");
        _value3 = default;
    }

    private Either(T3 value3)
    {
        _index = 3;
        _value0 = default;
        _value1 = default;
        _value2 = default; 
        _value3 = value3 ?? throw new ArgumentNullException($"{nameof(value3)}");
    }

    public TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1, Func<T2, TResult> f2, Func<T3, TResult> f3) =>
        _index switch
        {
            0 => f0(_value0!),
            1 => f1(_value1!),
            2 => f2(_value2!),
            3 => f3(_value3!),
            _ => throw new InvalidOperationException()
        };

    public Either<TResult0, TResult1, TResult2, TResult3> Map<TResult0, TResult1, TResult2, TResult3>(
        Func<T0, TResult0> f0,
        Func<T1, TResult1> f1,
        Func<T2, TResult2> f2,
        Func<T3, TResult3> f3)
    {
        return _index switch
        {
            0 => f0(_value0!),
            1 => f1(_value1!),
            2 => f2(_value2!),
            3 => f3(_value3!),
            _ => throw new InvalidOperationException()
        };
    }

    public Either<T0, T1, T2, T3> Do(Action<T0> f0, Action<T1> f1, Action<T2> f2, Action<T3> f3)
    {
        switch (_index)
        {
            case 0:
                f0(_value0!);
                return this;
            case 1:
                f1(_value1!);
                return this;
            case 2:
                f2(_value2!);
                return this;
            case 3:
                f3(_value3!);
                return this;
            default:
                throw new InvalidOperationException();
        }
    }

    public static implicit operator Either<T0, T1, T2, T3>(T0 t) => new(t);
    public static implicit operator Either<T0, T1, T2, T3>(T1 t) => new(t);
    public static implicit operator Either<T0, T1, T2, T3>(T2 t) => new(t);
    public static implicit operator Either<T0, T1, T2, T3>(T3 t) => new(t);
}