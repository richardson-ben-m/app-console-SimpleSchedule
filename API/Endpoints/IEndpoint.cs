namespace API.Endpoints;

public interface IEndpoint
{
    /// <summary>
    /// The input string that calls the endpoint.
    /// </summary>
    public abstract static string Address { get; }

    /// <summary>
    /// Calls the endpoint.
    /// </summary>
    /// <param name="args">The arguments to pass to the endpoint.</param>
    /// <returns>String result</returns>
    string CallEndpoint(string[] args);
}
