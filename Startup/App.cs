using API;

namespace Startup;

public class App
{
    public static void Run(Controller controller)
    {
        Console.WriteLine("SimpleSchedule.API.exe is running.");

        var inputString = Console.ReadLine();     
        Console.WriteLine(controller.RunCommand(inputString));

        Console.ReadLine();
    }
}