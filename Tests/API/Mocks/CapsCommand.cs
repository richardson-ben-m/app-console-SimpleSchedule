using API;

namespace Tests.API.Mocks
{
    internal class CapsCommand : ICommand
    {
        public string Run(string[] args)
        {
            return args[0].ToUpperInvariant();
        }
    }
}
