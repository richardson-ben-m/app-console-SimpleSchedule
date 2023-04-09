namespace API.Commands;

internal class ExitCommand : ICommand
{
    public static string CommandWord => "exit";

    /// <summary>
    /// Returns a string "ShutDown" to tell the application to close.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public string Run(string[] args)
    {
        return "ShutDown";
    }
}
