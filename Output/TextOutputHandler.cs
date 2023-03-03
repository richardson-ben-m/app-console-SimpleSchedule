namespace Output;

/// <summary>
/// OutputHandlerBase class for writing basic data to console.
/// </summary>
public class TextOutputHandler : OutputHandlerBase
{
    /// <summary>
    /// Writes line of text to the Console.
    /// </summary>
    /// <param name="text"></param>
    public override void OutputLineOfText(string text)
    {
        Console.WriteLine(text);
    }
}
