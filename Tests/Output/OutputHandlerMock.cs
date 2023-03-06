using Logic.Output;

namespace Tests.Output
{
    internal class OutputHandlerMock : OutputHandlerBase
    {
        #region Class Methods
        public override void OutputLineOfText(string text)
        {
            OutputLineOfTextString = text;
            OutputLineOfTextCallback?.Invoke(OutputLineOfTextString);
        }
        #endregion

        #region Mock Methods
        public string? OutputLineOfTextString { get; private set; }
        public Action<string>? OutputLineOfTextCallback { get; set; }

        public void Reset()
        {
            OutputLineOfTextString = null;
            OutputLineOfTextCallback = null;
        }

        public bool OutputLineOfTextWasCalled()
        {
            return OutputLineOfTextString != null;
        }

        public bool OutputLineOfTextWasCalledWithExpectedString(string textItShouldBeCalledWith)
        {
            return OutputLineOfTextString == textItShouldBeCalledWith;
        }
        #endregion
    }
}
