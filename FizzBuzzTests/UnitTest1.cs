using FluentAssertions;
using FluentAssertions.Execution;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void dsfghfdsgh()
    {
        Output.FizzBuzz(1).Should().Be("1");
    }
    
    [Test]
    public void shgfdghdfg()
    {
        Output.FizzBuzz(2).Should().Be("2");
    }
    
    [Test]
    public void sdfghdfghd()
    {
        Output.FizzBuzz(3).Should().Be("Fizz");
    }
    
    [Test]
    public void hgjfghjfgh()
    {
        Output.FizzBuzz(6).Should().Be("Fizz");
    }
    
}

public static class Output
{
    public static string FizzBuzz(int value)
    {
        if(value % 3 == 0)
        {
            return "Fizz";
        }
        return value.ToString();
    }
}