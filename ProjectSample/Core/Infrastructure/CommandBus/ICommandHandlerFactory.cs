using System.Collections.Generic;

namespace ProjectSample.Core.Infrastructure.CommandBus
{
    public interface ICommandHandlerFactory
    {
        IEnumerable<IHandleCommand<TCommand>> FindHandlers<TCommand>();
        void ReleaseHandlers<T>(IEnumerable<T> handlers);
    }
}