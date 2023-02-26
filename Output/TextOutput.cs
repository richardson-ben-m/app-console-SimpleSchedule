namespace Output;

public class TextOutput : ITextOutput
{
    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
}
