using API;

namespace Tests.API
{
    internal class ControllerMock : Controller
    {
        //private static readonly CommandFactoryMock _commandFactoryMock = new();
        public ControllerMock() : base((str) => new CapsCommand()) { }

        public override string RunCommand(string? command)
        {
            var args = new string[] { command ?? "" };
            return new CapsCommand().Run(args);
        }
    }
}
