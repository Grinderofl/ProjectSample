using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSample.Core.Infrastructure.DataAccess
{
    public interface IUnitOfWork
    {
        void Begin();
        bool Commit();
        void Rollback();
    }
}
