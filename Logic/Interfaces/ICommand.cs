using Logic.Classes;
using Models;

namespace Logic.Interfaces;

public interface ICommand
{
    Schedule Execute(SaveCommandOptions options);
}
