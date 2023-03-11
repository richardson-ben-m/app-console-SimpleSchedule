using API;
using Microsoft.Extensions.DependencyInjection;
using Tests.API.Mocks;

namespace Tests.API;

internal class CommandFactoryTests
{
    private ServiceProvider _serviceProvider;
    private CommandFactory _commandFactory;

    private const string CommandName = "test";

    [SetUp]
    public void SetUp()
    {
        CommandFactory.RegisteredCommands.Clear();
        CommandFactory.RegisteredCommands.Add(CommandName, typeof(CapsCommand));

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<CapsCommand>();
        _serviceProvider = serviceCollection.BuildServiceProvider();
        _commandFactory = new CommandFactory(_serviceProvider);
    }

    [Test]
    public void GetCommand_ReceivesValidCommand_ReturnsCommand()
    {
        var result = _commandFactory.GetCommand(CommandName);

        result.Should().BeAssignableTo<CapsCommand>();
    }


    [TestCase(null)]
    [TestCase("")]
    [TestCase("this is not a command")]
    public void GetCommand_ReceivesInvalidInput_ThrowsArgumentException(string commandName)
    {
        TestThrowsArgumentException(commandName);
    }

    [Test]
    public void GetCommand_RegisteredClassIsNotICommand_ThrowsArgumentException()
    {
        CommandFactory.RegisteredCommands.Clear();
        CommandFactory.RegisteredCommands.Add(CommandName, typeof(IServiceProvider));

        TestThrowsArgumentException(CommandName);
    }

    private void TestThrowsArgumentException(string commandName)
    {
        var wasThrown = false;
        try
        {
            _commandFactory.GetCommand(commandName);
        }
        catch (ArgumentException)
        {
            wasThrown = true;
        }
        wasThrown.Should().BeTrue();
    }
}
