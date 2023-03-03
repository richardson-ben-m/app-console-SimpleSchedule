using Input;
using Logic.Classes;
using Logic.Input;
using Logic.Interfaces;
using Logic.Output;

namespace SimpleSchedule;

public class Startup
{
    private readonly OutputHandlerBase _textOutput;
    private readonly UserInputHandlerBase _inputReader;
    private readonly ICommand _command;

    public Startup(OutputHandlerBase textOutput, UserInputHandlerBase inputReader, ICommand command)
    {
        _textOutput = textOutput;
        _inputReader = inputReader;
        _command = command;
    }

    public void Run()
    {
        _textOutput.OutputLineOfText("Welcome to the SimpleSchedule app.");
        _textOutput.OutputLineOfText("Hit Enter and save a Reminder object to storage.");
        _inputReader.ReadLine();
        var reminder = _command.Execute(new SaveCommandOptions("", new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0)));
        if (reminder == null) 
        {
            _textOutput.OutputLineOfText("Reminder Save failed!");
        }
        _textOutput.OutputLineOfText($"Object saved: {reminder}");
    }
}