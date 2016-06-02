using System.Linq;

namespace ProjectSample.Infrastructure.CommandBus.Impl
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Send<T>(T command)
        {
            var handlers = _commandHandlerFactory.FindHandlers<T>().ToArray();
            foreach(var handler in handlers)
                handler.Handle(command);
            _commandHandlerFactory.ReleaseHandlers(handlers);
        }
    }
}