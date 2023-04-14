﻿using API;
using Microsoft.Extensions.Configuration;

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

        string? result;
        do
        {
            var inputString = Console.ReadLine();
            result = controller.RunCommand(inputString);
            Console.WriteLine(result);

        } while (result != "ShutDown");
    }
}