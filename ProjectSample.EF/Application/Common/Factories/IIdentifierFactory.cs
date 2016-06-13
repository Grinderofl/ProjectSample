using ProjectSample.EF.Infrastructure.Common.Models;

namespace ProjectSample.EF.Application.Common.Factories
{
    public interface IIdentifierFactory<TEntity>
    {
        Identifier CreateIdentifier();
    }
}