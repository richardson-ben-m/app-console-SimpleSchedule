using API.Endpoints;

namespace Tests.API.Mocks;

/// <summary>
/// An instance of IEndpoint that just returns the address string.
/// </summary>
internal class EchoEndpoint : IEndpoint
{
    public static string Address => "echo";

    /// <summary>
    /// Provide a string array, it returns the first item in the array as is.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public string CallEndpoint(string[] args)
    {
        return args[0];
    }
}
