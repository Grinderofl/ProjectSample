using ProjectSample.Core.Common.Models;

namespace ProjectSample.Application.Common.Factories
{
    public interface IIdentifierFactory<TEntity>
    {
        Identifier CreateIdentifier();
    }
}