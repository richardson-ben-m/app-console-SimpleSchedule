namespace Input;

/// <summary>
/// Wrapper class for Console.Read commands
/// </summary>
public sealed class InputReader : InputReaderBase
{
    public override string? ReadLine()
    {
        return Console.ReadLine();
    }
}
