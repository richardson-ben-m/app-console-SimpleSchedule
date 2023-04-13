using API.Commands;

namespace Tests.API.Mocks;

/// <summary>
/// An instance of ICommand that just returns the command string.
/// </summary>
internal class EchoCommand : ICommand
{
    public static string CommandWord => "echo";

    /// <summary>
    /// Provide a string array, it returns the first item in the array as is.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public string Run(string[] args)
    {
        return args[0];
    }
}
