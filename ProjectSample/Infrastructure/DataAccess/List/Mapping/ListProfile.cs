using System.Collections.Generic;
using AutoMapper;
using ProjectSample.Infrastructure.DataAccess.List.Models;

namespace ProjectSample.Infrastructure.DataAccess.List.Mapping
{
    public abstract class AbstractListProfile<TEntity, TModel> : Profile
    {
        protected override void Configure()
        {
            CreateMap<TEntity, TModel>();
            CreateMap<ListResult<TEntity>, ListModel<TModel>>()
                .ConstructUsing(Ctor);
        }

        private static ListModel<TModel> Ctor(ResolutionContext resolutionContext)
        {
            var x = resolutionContext.SourceValue as ListResult<TEntity>;
            var items = resolutionContext.Engine.Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(x.Items);
            return new ListModel<TModel>(items, x.Total, x.RowsPerPage, x.Page);
        }
    }
}