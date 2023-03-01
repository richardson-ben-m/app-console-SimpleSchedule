using Logic.Classes;
using Models;

namespace Logic.Interfaces;

public interface ICommand
{
    Reminder Execute(SaveCommandOptions options);
}
