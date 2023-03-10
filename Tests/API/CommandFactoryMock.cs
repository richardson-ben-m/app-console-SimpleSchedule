using API;

namespace Tests.API
{
    internal class CommandFactoryMock : CommandFactory
    {
        public override string RunCommand(string? command)
        {
            var args = new string[] { command ?? "" };
            return new CapsCommand().Run(args);
        }
    }
}
