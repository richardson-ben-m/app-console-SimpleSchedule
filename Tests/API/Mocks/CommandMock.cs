using API;

namespace Tests.API.Mocks
{
    internal class CommandMock : ICommand
    {
        public bool RunWasCalled { get; set; }
        public string[] RunArgs { get; set; }
        public string RunReturnValue { get; set; }
        private const string DefaultRunReturnValue = "CommandMock.Run";
        
        public CommandMock()
        {
            RunArgs = Array.Empty<string>();
            RunReturnValue = DefaultRunReturnValue;
        }

        public void ResetMock()
        { 
            RunWasCalled = false;
            RunArgs = Array.Empty<string>();
            RunReturnValue= DefaultRunReturnValue;
        }

        public string Run(string[] args)
        {
            RunWasCalled = true;
            RunArgs = args;
            return "CommandMock.Run";
        }
    }
}
