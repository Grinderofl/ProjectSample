using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Infrastructure.NHibernate.Queries
{
    public class GenericEntityQueryObject<TEntity, TPk> : NhQueryObject<IEnumerable<TEntity>> where TEntity : Entity<TPk>
    {
        private readonly int _page;
        private readonly int _itemsPerPage;

        public GenericEntityQueryObject(int page, int itemsPerPage)
        {
            _page = page;
            _itemsPerPage = itemsPerPage;
        }

        protected override IEnumerable<TEntity> ExecuteCore(ISession session)
        {
            return session.Query<TEntity>().OrderBy(x => x.Id).Skip(_page*_itemsPerPage).Take(_itemsPerPage);
        }
    }
}