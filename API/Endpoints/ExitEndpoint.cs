namespace API.Endpoints;

internal class ExitEndpoint : IEndpoint
{
    public static string Address => "exit";

    /// <summary>
    /// Returns a string "ShutDown" to tell the application to close.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public string CallEndpoint(string[] args)
    {
        return "ShutDown";
    }
}
