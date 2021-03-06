﻿using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Infrastructure.NHibernate.Queries
{
    public class GenericEntityQueryObject<TEntity, TPk> : NhQueryObject<IEnumerable<TEntity>>
        where TEntity : Entity<TPk>
    {
        private readonly int _itemsPerPage;
        private readonly int _page;

        public GenericEntityQueryObject(int page, int itemsPerPage)
        {
            _page = page;
            _itemsPerPage = itemsPerPage;
        }

        protected override IEnumerable<TEntity> ExecuteCore(ISession session)
        {
            return session.Query<TEntity>().OrderBy(x => x.Id).Skip((_page - 1)*_itemsPerPage).Take(_itemsPerPage);
        }
    }
}