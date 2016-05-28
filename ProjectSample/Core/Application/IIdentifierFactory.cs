using ProjectSample.Core.Application.Models;

namespace ProjectSample.Core.Application
{
    public interface IIdentifierFactory<TEntity>
    {
        Identifier CreateIdentifier();
    }
}