namespace ProjectSample.Infrastructure.CommandBus
{
    public interface ICommandBus
    {
        void Send<T>(T command);
    }
}