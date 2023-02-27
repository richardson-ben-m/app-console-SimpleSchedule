using Input;
using NUnit.Framework;

namespace Tests.Input;

public class CommandFactoryTests
{
    [TestCase("save", typeof(SaveCommand))]
    [TestCase("Save", typeof(SaveCommand))]
    [TestCase("SAVE", typeof(SaveCommand))]
    public void ReadCommand_ValidCommandName_ReturnsRequestedCommand(string commandString, Type expectedCommandType)
    {
        var factory = new CommandFactory();
        var result = factory.GetCommand(commandString);
        result.Should().BeAssignableTo(expectedCommandType);
    }

    [TestCase("")]
    [TestCase("not a valid entry")]
    public void GetCommand_InvalidCommandName_ThrowsArgumentException(string commandString)
    {
        var factory = new CommandFactory();
        Action act = () => factory.GetCommand(commandString);
        act.Should().Throw<ArgumentException>();
    }
}
