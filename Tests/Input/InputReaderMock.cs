using Input;

namespace Tests.Input;

/// <summary>
/// Mock object of InputReaderBase, used in testing.
/// </summary>
internal class InputReaderMock : InputReaderBase
{
    public override string? ReadLine()
    {
        return "hello";
    }
}
