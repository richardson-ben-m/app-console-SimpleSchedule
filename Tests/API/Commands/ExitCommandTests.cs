using API.Commands;

namespace Tests.API.Commands
{
    internal class ExitCommandTests
    {
        private ExitCommand _exitCommand;

        [SetUp]
        public void SetUp()
        {
            _exitCommand = new ExitCommand();
        }

        [Test]
        public void Run_ReturnsShutDown()
        {
            var result = _exitCommand.Run(Array.Empty<string>());

            result.Should().Be("ShutDown");
        }
    }
}
