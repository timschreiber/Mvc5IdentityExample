using Mvc5IdentityExample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc5IdentityExample.Data.Dapper.Repositories
{
    internal class ExternalLoginRepository : Repository, IExternalLoginRepository
    {
        public ExternalLoginRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Domain.Entities.ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.ExternalLogin> GetByProviderAndKeyAsync(System.Threading.CancellationToken cancellationToken, string loginProvider, string providerKey)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.ExternalLogin> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.ExternalLogin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.ExternalLogin>> GetAllAsync(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.ExternalLogin> PageAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.ExternalLogin>> PageAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.ExternalLogin>> PageAllAsync(System.Threading.CancellationToken cancellationToken, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.ExternalLogin FindById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.ExternalLogin> FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.ExternalLogin> FindByIdAsync(System.Threading.CancellationToken cancellationToken, object id)
        {
            throw new NotImplementedException();
        }

        public void Add(Domain.Entities.ExternalLogin entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.ExternalLogin entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.ExternalLogin entity)
        {
            throw new NotImplementedException();
        }
    }
}
