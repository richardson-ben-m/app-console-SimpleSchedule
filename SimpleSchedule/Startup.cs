using Logic.Output;

//namespace Logic;
namespace SimpleSchedule;

public class Startup
{
    private ITextOutput _textOutput;

    public Startup(ITextOutput textOutput)
    {
        _textOutput = textOutput;
    }

    public void Run(string[] args)
    {
        _textOutput.WriteLine("Hello, World!");
        _textOutput.WriteLine("From Startup class");
    }
}