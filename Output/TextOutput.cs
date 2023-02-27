namespace Output;

/// <summary>
/// IOutput class for writing basic data to console.
/// </summary>
public class TextOutput : IOutput
{
    /// <summary>
    /// Writes line of text to the Console.
    /// </summary>
    /// <param name="text"></param>
    public void OutputLineOfText(string text)
    {
        Console.WriteLine(text);
    }
}
