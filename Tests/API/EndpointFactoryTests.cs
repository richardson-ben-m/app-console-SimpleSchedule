using API;
using Microsoft.Extensions.DependencyInjection;
using Tests.API.Mocks;

namespace Tests.API;

internal class EndpointFactoryTests
{
    private ServiceProvider _serviceProvider;
    private EndpointFactory _endpointFactory;

    [SetUp]
    public void SetUp()
    {
        EndpointFactory.RegisteredEndpoints.Clear();
        EndpointFactory.RegisteredEndpoints.Add(CapsEndpoint.Address, typeof(CapsEndpoint));

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<CapsEndpoint>();
        _serviceProvider = serviceCollection.BuildServiceProvider();
        _endpointFactory = new EndpointFactory(_serviceProvider);
    }

    [Test]
    public void GetEndpoint_ReceivesValidEndpointAddress_ReturnsEndpointObject()
    {
        var result = _endpointFactory.GetEndpoint(CapsEndpoint.Address);

        result.Should().BeAssignableTo<CapsEndpoint>();
    }


    [TestCase(null)]
    [TestCase("")]
    [TestCase("this is not an endpoint")]
    public void GetEndpoint_ReceivesInvalidEndpointAddress_ThrowsArgumentException(string endpointAddress)
    {
        TestThrowsArgumentException(endpointAddress);
    }

    [Test]
    public void GetEndpoint_RegisteredClassIsNotIEndpoint_ThrowsArgumentException()
    {
        EndpointFactory.RegisteredEndpoints.Clear();
        EndpointFactory.RegisteredEndpoints.Add(CapsEndpoint.Address, typeof(IServiceProvider));

        TestThrowsArgumentException(CapsEndpoint.Address);
    }

    private void TestThrowsArgumentException(string endpointAddress)
    {
        var wasThrown = false;
        try
        {
            _endpointFactory.GetEndpoint(endpointAddress);
        }
        catch (ArgumentException)
        {
            wasThrown = true;
        }
        wasThrown.Should().BeTrue();
    }
}
