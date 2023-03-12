namespace API.Commands;

public interface ICommand
{
    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="args">The arguments to run with.</param>
    /// <returns>String result</returns>
    string Run(string[] args);
}
