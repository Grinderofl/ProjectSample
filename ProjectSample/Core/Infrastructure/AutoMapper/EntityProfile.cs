using AutoMapper;

namespace ProjectSample.Core.Infrastructure.AutoMapper
{
    public abstract class EntityProfile<TEntity, TViewModel, TFieldsModel, TListItemModel> : Profile
    {
        protected override void Configure()
        {
            CreateViewModelMap();
            CreateFieldsModelMap();
            CreateListItemMap();
        }

        protected virtual void CreateViewModelMap()
        {
            CreateMap<TEntity, TViewModel>();
        }

        protected virtual void CreateFieldsModelMap()
        {
            CreateMap<TEntity, TFieldsModel>();
            CreateMap<TFieldsModel, TEntity>();
        }

        protected virtual void CreateListItemMap()
        {
            CreateMap<TEntity, TListItemModel>();
        }
    }
}