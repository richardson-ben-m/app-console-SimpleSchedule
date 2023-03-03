namespace Logic.Output;

/// <summary>
/// Base class for basic data output.
/// </summary>
public abstract class OutputHandlerBase
{
    /// <summary>
    /// Outputs a line of text.
    /// </summary>
    /// <param name="text"></param>
    public abstract void OutputLineOfText(string text);
}
