using System.Web.UI.WebControls.WebParts;

namespace ProjectSample.Core.Infrastructure.CommandBus
{
    public interface ICommandBus
    {
        void Send<T>(T command);
    }
}