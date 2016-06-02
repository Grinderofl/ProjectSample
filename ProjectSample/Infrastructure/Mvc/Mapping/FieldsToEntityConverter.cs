using AutoMapper;

namespace ProjectSample.Infrastructure.Mvc.Mapping
{
    public abstract class FieldsToEntityConverter<TFields, TEntity> : ITypeConverter<TFields, TEntity>
        where TFields : class where TEntity : class
    {
        public TEntity Convert(ResolutionContext context)
            =>
                context.DestinationValue == null
                    ? Create(context.SourceValue as TFields)
                    : Update(context.SourceValue as TFields, context.DestinationValue as TEntity);

        protected abstract TEntity Update(TFields fields, TEntity entity);

        protected abstract TEntity Create(TFields fields);
    }
}