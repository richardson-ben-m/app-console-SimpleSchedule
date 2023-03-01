using Logic.Classes;
using Models;

namespace Logic.Interfaces;

//public interface ICommand<in TIn, out TOut> where TIn : ICommandOptions where TOut : class
//{
//    TOut Execute(TIn options);
//}
public interface ICommand
{
    Reminder Execute(SaveCommandOptions options);
}
