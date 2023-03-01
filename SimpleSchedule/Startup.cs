using Input;
using Logic.Classes;
using Logic.Interfaces;
using Logic.Output;

namespace SimpleSchedule;

public class Startup
{
    private readonly IOutput _textOutput;
    private readonly InputReaderBase _inputReader;
    private readonly ICommand _command;

    public Startup(IOutput textOutput, InputReaderBase inputReader, ICommand command)
    {
        _textOutput = textOutput;
        _inputReader = inputReader;
        _command = command;
    }

    public void Run(string[] args)
    {
        _textOutput.OutputLineOfText("Welcome to the SimpleSchedule app.");
        _inputReader.ReadLine();
        _command.Execute(new SaveCommandOptions("", new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0)));
    }
}