using Logic.Input;

namespace Input;

/// <summary>
/// Wrapper class for Console.Read commands
/// </summary>
internal sealed class UserTextInputHandler : UserInputHandlerBase
{
    public override string? ReadLine()
    {
        return Console.ReadLine();
    }
}
