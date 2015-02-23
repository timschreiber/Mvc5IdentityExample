using Mvc5IdentityExample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc5IdentityExample.Data.Dapper.Repositories
{
    internal class RoleRepository : Repository, IRoleRepository
    {
        public RoleRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Domain.Entities.Role FindByName(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Role> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Role>> GetAllAsync(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Role> PageAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Role>> PageAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Role>> PageAllAsync(System.Threading.CancellationToken cancellationToken, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Role FindById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Role> FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Role> FindByIdAsync(System.Threading.CancellationToken cancellationToken, object id)
        {
            throw new NotImplementedException();
        }

        public void Add(Domain.Entities.Role entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Role entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
