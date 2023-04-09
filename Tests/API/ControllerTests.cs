using API;
using Tests.API.Mocks;

namespace Tests.API;

internal class ControllerTests
{
    private CommandFactoryMock _commandFactory;
    private Controller _controller;
    private CommandMock _command;

    private readonly string ValidCommand = CommandMock.CommandWord;

    [SetUp]
    public void SetUp()
    {
        _command = new CommandMock();
        _commandFactory = new CommandFactoryMock();
        _commandFactory.AddCommand(ValidCommand, _command);
        _controller = new Controller(_commandFactory);
    }

    [Test]
    public void RunCommand_ReceivesValidCommand_ReturnsOutputFromCommand()
    {
        var result = _controller.RunCommand(ValidCommand);

        _command.RunWasCalled.Should().BeTrue();
        _command.RunArgs.Should().BeEmpty();
        result.Should().Be(_command.RunReturnValue);
    }

    [Test]
    public void RunCommand_ReceivesNull_ThrowsArgumentException()
    {
        var wasThrown = false;
        try
        {
            _controller.RunCommand(null);
        }
        catch (ArgumentException)
        {
            wasThrown = true;
        }
        wasThrown.Should().BeTrue();
        _command.RunWasCalled.Should().BeFalse();
    }

    [Test]
    public void RunCommand_ReceivesStringWithValidCommandAndParams_ReturnsOutputFromCommand()
    {
        var arg1 = "arg1";
        var arg2 = "arg2";
        var commandWithArgs = $"{ValidCommand} /{arg1} /{arg2}";

        var result = _controller.RunCommand(commandWithArgs);

        _command.RunWasCalled.Should().BeTrue();
        _command.RunArgs.Should().HaveCount(2)
            .And.Contain(arg1)
            .And.Contain(arg2);
        result.Should().Be(_command.RunReturnValue);
    }

}
