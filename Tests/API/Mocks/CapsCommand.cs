using API;

namespace Tests.API.Mocks;

/// <summary>
/// An instance of ICommand with simple behavior. Used for testing if an ICommand is called, it runs.
/// </summary>
internal class CapsCommand : ICommand
{
    /// <summary>
    /// Provide a string array, it returns the first item in the array with all caps.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public string Run(string[] args)
    {
        return args[0].ToUpperInvariant();
    }
}
