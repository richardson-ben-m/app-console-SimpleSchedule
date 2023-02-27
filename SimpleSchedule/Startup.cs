using Input;
using Logic.Output;

namespace SimpleSchedule;

public class Startup
{
    private readonly IOutput _textOutput;
    private readonly InputReaderBase _inputReader;

    public Startup(IOutput textOutput, InputReaderBase inputReader)
    {
        _textOutput = textOutput;
        _inputReader = inputReader;
    }

    public void Run(string[] args)
    {
        _textOutput.OutputLineOfText("Welcome to the SimpleSchedule app.");
        var command = _inputReader.ReadLine();
        var factory = new CommandFactory();
        factory.GetCommand(command!);
    }
}