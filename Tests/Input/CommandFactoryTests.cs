using Input;

namespace Tests.Input;

public class CommandFactoryTests
{
    [Test]
    public void ReadCommandReturnsRequestedCommand()
    {
        var factory = new CommandFactory();

        var result = factory.GetCommand("save");

        result.Should().Be(Commands.Save);
    }
}
