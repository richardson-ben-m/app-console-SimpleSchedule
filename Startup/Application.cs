namespace Startup;

public class Application
{
    public static void Run()
    {
        Console.WriteLine("SimpleSchedule.API.exe is running.");
        var input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
            // Play beep sound once
            Console.Beep();

        Console.ReadLine();
    }
}