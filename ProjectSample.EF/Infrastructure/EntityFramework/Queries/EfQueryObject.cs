using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectSample.EF.Infrastructure.EntityFramework.Queries
{
    public abstract class EfQueryObject<TResult>
    {
        public abstract TResult Execute(DbContext context);
    }
}