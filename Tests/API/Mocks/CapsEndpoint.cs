using API.Endpoints;

namespace Tests.API.Mocks;

/// <summary>
/// An instance of IEndpoint with simple behavior. Used for testing if an IEndpoint is called, it runs.
/// </summary>
internal class CapsEndpoint : IEndpoint
{
    public static string Address => "caps";

    /// <summary>
    /// Provide a string array, it returns the first item in the array with all caps.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public string CallEndpoint(string[] args)
    {
        return args[0].ToUpperInvariant();
    }
}
