using Logic.Classes;
using Logic.Input;
using Logic.Output;
using Models;

namespace Logic.Interfaces;

public interface ICommand
{
    SaveCommandOptions GetOptionsFromUser(OutputHandlerBase outputHandler, UserInputHandlerBase inputHandler);
    Reminder Execute(SaveCommandOptions options);
}
