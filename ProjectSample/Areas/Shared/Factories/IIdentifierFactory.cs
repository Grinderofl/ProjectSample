using ProjectSample.Areas.Shared.Models;

namespace ProjectSample.Areas.Shared.Factories
{
    public interface IIdentifierFactory<TEntity>
    {
        Identifier CreateIdentifier();
    }
}