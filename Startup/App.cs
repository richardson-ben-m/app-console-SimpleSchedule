using API;

namespace Startup;

public class App
{
    public static void Run(CommandFactory commandFactory)
    {
        Console.WriteLine("SimpleSchedule.API.exe is running.");

        var inputString = Console.ReadLine();     
        Console.WriteLine(commandFactory.RunCommand(inputString));

        Console.ReadLine();
    }
}