using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc5IdentityExample.Data.Dapper.Repositories
{
    internal abstract class Repository
    {
        protected UnitOfWork UnitOfWork { get; private set; }

        internal Repository(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
