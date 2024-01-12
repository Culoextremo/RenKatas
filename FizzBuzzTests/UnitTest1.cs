using FluentAssertions;
using FluentAssertions.Execution;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void dsfghfdsgh()
    {
        var sut = new Output();
        Output.FizzBuzz(1).Should().Be("1");
    }
    
    [Test]
    public void shgfdghdfg()
    {
        var sut = new Output();
        Output.FizzBuzz(2).Should().Be("2");
    }
    
    [Test]
    public void sdfghdfghd()
    {
        var sut = new Output();
        Output.FizzBuzz(3).Should().Be("Fizz");
    }
    
    [Test]
    public void hgjfghjfgh()
    {
        var sut = new Output();
        Output.FizzBuzz(6).Should().Be("Fizz");
    }
    
}

public class Output
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