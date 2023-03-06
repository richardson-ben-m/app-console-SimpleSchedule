using Logic.Input;

namespace Tests.Input;

/// <summary>
/// Mock object of UserInputHandlerBase, used in testing.
/// </summary>
internal class UserInputHandlerMock : UserInputHandlerBase
{
    /// <summary>
    /// If not set, defaults to value "hello". If set, even if set to null, uses set value.
    /// </summary>
    public string? ReadLineResponse {
        get => _readLineResponse;
        set 
        { 
            _readLineResponse = value;
            _readLineResponseSet = true;
        } 
    }
    private string? _readLineResponse;
    private bool _readLineResponseSet;
    public override string? ReadLine()
    {
        return _readLineResponseSet ? _readLineResponse : "hello";
    }
}
