using API;

namespace Startup;

/// <summary>
/// Class to run the application.
/// </summary>
public class App
{
    /// <summary>
    /// Run the application.
    /// </summary>
    /// <param name="controller"></param>
    public static void Run(Controller controller)
    {
        Console.WriteLine("SimpleSchedule.API.exe is running.");

        var inputString = Console.ReadLine();     
        Console.WriteLine(controller.RunCommand(inputString));

        Console.ReadLine();
    }
}