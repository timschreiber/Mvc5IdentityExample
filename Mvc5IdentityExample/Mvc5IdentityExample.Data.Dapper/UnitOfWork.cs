using Mvc5IdentityExample.Data.Dapper.Repositories;
using Mvc5IdentityExample.Domain;
using Mvc5IdentityExample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc5IdentityExample.Data.Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        
        private IClaimRepository _claimRepository;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(string nameOrConnectionString)
        {
            var connectionFactory = new ConnectionFactory(nameOrConnectionString);
            _connection = connectionFactory.Create();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        internal IDbTransaction Transaction { get { return _transaction; } }
        internal IDbConnection Connection { get { return _connection; } }

        public IClaimRepository ClaimRepository
        {
            get { return _claimRepository ?? (_claimRepository = new ClaimRepository(this)); }
        }

        public Domain.Repositories.IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(this)); }
        }

        public Domain.Repositories.IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(this)); }
        }

        public Domain.Repositories.IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(this)); }
        }

        public void SaveChanges()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        public Task SaveChangesAsync()
        {
            SaveChanges();
            return Task.FromResult(0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    if(_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if(_connection != null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                disposed = true;
            }
        }

        private void resetRepositories()
        {
            _claimRepository = null;
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
