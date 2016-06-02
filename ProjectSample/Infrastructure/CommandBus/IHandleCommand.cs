namespace ProjectSample.Infrastructure.CommandBus
{
    public interface IHandleCommand<in TCommand>
    {
        void Handle(TCommand command);
    }
}