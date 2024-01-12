using FluentAssertions;
using FluentAssertions.Execution;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void dsfghfdsgh()
    {
        FizzBuzz.Of(1).Should().Be("1");
    }
    
    [Test]
    public void shgfdghdfg()
    {
        FizzBuzz.Of(2).Should().Be("2");
    }
    
    [Test]
    public void sdfghdfghd()
    {
        FizzBuzz.Of(3).Should().Be("Fizz");
    }
    
    [Test]
    public void hgjfghjfgh()
    {
        FizzBuzz.Of(6).Should().Be("Fizz");
    }
    
}

public static class FizzBuzz
{
    public static string Of(int value)
    {
        if(value % 3 == 0)
        {
            return "Fizz";
        }
        return value.ToString();
    }
}