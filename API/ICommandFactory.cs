using API.Commands;

namespace API;

public interface ICommandFactory
{
    /// <summary>
    /// Returns the <see cref="ICommand"/> registered under the given name.
    /// </summary>
    /// <param name="commandName">The name of the <see cref="ICommand"/> to return.</param>
    /// <returns>The registered <see cref="ICommand"/> object.</returns>
    ICommand GetCommand(string commandName);
}
