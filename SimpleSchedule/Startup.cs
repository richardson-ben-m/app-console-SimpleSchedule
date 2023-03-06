using Logic.Classes;
using Logic.Input;
using Logic.Interfaces;
using Logic.Output;

namespace SimpleSchedule;

public class Startup
{
    private readonly OutputHandlerBase _outputHandler;
    private readonly UserInputHandlerBase _inputHandler;
    private readonly ICommand _command;

    public Startup(OutputHandlerBase outputHandler, UserInputHandlerBase inputHandler, ICommand command)
    {
        _outputHandler = outputHandler;
        _inputHandler = inputHandler;
        _command = command;
    }

    public void Run()
    {
        _outputHandler.OutputLineOfText("Welcome to the SimpleSchedule app.");
        _command.GetOptionsFromUser(_outputHandler, _inputHandler);
        var reminder = _command.Execute(new SaveCommandOptions("", new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0)));
        if (reminder == null) 
        {
            _outputHandler.OutputLineOfText("Reminder Save failed!");
        }
        _outputHandler.OutputLineOfText($"Object saved: {reminder}");
    }
}