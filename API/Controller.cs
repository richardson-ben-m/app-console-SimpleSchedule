namespace API;

/// <summary>
/// Class for triggering <see cref="IEndpoint"/>s using string inputs.
/// </summary>
public class Controller
{
    private readonly IEndpointFactory _endpointFactory;

    public Controller(IEndpointFactory endpointFactory)
    {
        _endpointFactory = endpointFactory;
    }

    /// <summary>
    /// Triggers an endpoint using the given input.
    /// </summary>
    /// <param name="input">A string separated by '/'. The first element is the endpoint to trigger. Other elements are the params used when the endpoint is triggered.</param>
    /// <returns>A string result from the executed endpoint.</returns>
    /// <exception cref="ArgumentException"></exception>
    public virtual string TriggerEndpoint(string? input)
    {
        if (input == null) throw new ArgumentException($"No Endpoint was called.");

        var endpointName = ReadEndpointFromInput(input);
        var endpoint = _endpointFactory.GetEndpoint(endpointName);

        var args = ArgsFromInput(input);
        return endpoint.CallEndpoint(args);
    }

    private static string ReadEndpointFromInput(string input)
    {
        return input.Split("/")[0].Trim();
    }

    private static string[] ArgsFromInput(string input)
    {
        var inArgs = input.Split("/");
        var outArgs = new string[inArgs.Length - 1];
        for (int i = 1; i < inArgs.Length; i++)
        {
            outArgs[i - 1] = inArgs[i].Trim();
        }
        return outArgs;
    }
}
