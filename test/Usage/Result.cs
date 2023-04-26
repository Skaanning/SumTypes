using SumTypes;
using SumTypes.Results;

namespace TestProject1;

public class Result<T> : Result<T, IEnumerable<ErrorResult>> 
{
    private Result(T value) : base(value)
    {
    }

    private Result(IEnumerable<ErrorResult> errorResult) : base(errorResult)
    {
    }

    private Result(ErrorResult errorResult) : base(new []{errorResult})
    {
    }
    
    public static implicit operator Result<T>(ErrorResult err) => new(err);
    public static implicit operator Result<T>(List<ErrorResult> err) => new(err);
    public static implicit operator Result<T>(ErrorResult[] err) => new(err);
    public static implicit operator Result<T>(T t) => new(t);
}

public class UnitResult : UnitResult<ErrorResult>
{
    private UnitResult(Unit unit) : base(unit)
    {
    }


    private UnitResult(ErrorResult errorResult) : base(errorResult)
    {
    }
    
    public static implicit operator UnitResult(ErrorResult t) => new(t);
    public static implicit operator UnitResult(Unit u) => new(u);
}

public enum HttpErrorType
{
    Unexpected = 0, 
    Validation = 1,
    NotFound = 2,
    Conflict = 3,
    Authentication = 4,
    Authorization = 5,
    Timeout = 6,
    InternalServerError = 7
}

public static class Errors
{
    public static class Generic
    {
        public static readonly ErrorResult Explosion = new($"{nameof(Explosion)}", "Unable to find user", $"{nameof(Generic)}.{nameof(Explosion)}", HttpErrorType.InternalServerError);
        
    }

    public static class Users
    {
        public static readonly ErrorResult UserNotFound = new($"{nameof(UserNotFound)}", "Unable to find user", $"{nameof(Users)}.{nameof(UserNotFound)}", HttpErrorType.NotFound);
    }
}

public readonly record struct ErrorResult(string Title, string Description, string ErrorCode, HttpErrorType ErrorType);

public class A
{
    public Result<int> S(int i, int j)
    {
        if (j == 0)
            return Errors.Generic.Explosion;
        
        return i/j;
    }
    
    public UnitResult GetUser(int i, int j)
    {
        if (j == 0)
            return Errors.Users.UserNotFound;
        
        return UnitResult.Ok;
    }
}