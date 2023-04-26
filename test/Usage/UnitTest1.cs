using Xunit.Abstractions;

namespace TestProject1;

public class UnitTest1
{
    private readonly ITestOutputHelper _outputHelper;

    public UnitTest1(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Test1()
    {
        var a = new A();
        var i = 5;
        var j = 0;
        var result = a.S(i, j);

        var errorType = result.Do(
            number => Assert.Equal(number, i/j),
            errors => Assert.Contains(Errors.Users.UserNotFound, errors));
    }
}