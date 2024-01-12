using FluentAssertions;
using FluentAssertions.Execution;
using static FizzBuzz;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void dsfghfdsgh()
    {
        FizzBuzzOf(1).Should().Be("1");
    }
    
    [Test]
    public void shgfdghdfg()
    {
        FizzBuzzOf(2).Should().Be("2");
    }
    
    [Test]
    public void sdfghdfghd()
    {
        FizzBuzzOf(3).Should().Be("Fizz");
    }
    
    [Test]
    public void hgjfghjfgh()
    {
        FizzBuzzOf(6).Should().Be("Fizz");
    }
    
    [Test]
    public void dfghfdgh()
    {
        FizzBuzzOf(10).Should().Be("Buzz");
    }
}

public static class FizzBuzz
{
    public static string FizzBuzzOf(int value)
    {
        if(value % 3 == 0)
        {
            return "Fizz";
        }
        if(value % 5 == 0)
        {
            return "Buzz";
        }
        
        return value.ToString();
    }
}