namespace API.Commands;

public interface ICommand
{
    /// <summary>
    /// The input string that executes the command.
    /// </summary>
    public abstract static string RunCommand { get; }

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="args">The arguments to run with.</param>
    /// <returns>String result</returns>
    string Run(string[] args);
}
