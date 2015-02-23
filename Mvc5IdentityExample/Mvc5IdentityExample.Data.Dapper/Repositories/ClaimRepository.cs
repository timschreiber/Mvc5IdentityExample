using Mvc5IdentityExample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Mvc5IdentityExample.Domain.Entities;
using Mvc5IdentityExample.Data.Dapper.Proxies;

namespace Mvc5IdentityExample.Data.Dapper.Repositories
{
    internal class ClaimRepository : Repository, IClaimRepository
    {
        internal ClaimRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<Claim> GetAll()
        {
            var claimProxies = UnitOfWork.Connection
                .Query<Claim>("SELECT ClaimId, UserId, ClaimType, ClaimValue FROM Claim", transaction: UnitOfWork.Transaction)
                .Select(x => new ClaimProxy(UnitOfWork) { ClaimId = x.ClaimId, UserId = x.UserId, ClaimType = x.ClaimType, ClaimValue = x.ClaimValue });
            return new List<Claim>(claimProxies);
        }

        public Task<List<Claim>> GetAllAsync()
        {
            var claimProxies = UnitOfWork.Connection
                .Query<Claim>("SELECT ClaimId, UserId, ClaimType, ClaimValue FROM Claim", transaction: UnitOfWork.Transaction)
                .Select(x => new ClaimProxy(UnitOfWork) { ClaimId = x.ClaimId, UserId = x.UserId, ClaimType = x.ClaimType, ClaimValue = x.ClaimValue });
            return Task.FromResult<List<Claim>>(new List<Claim>(claimProxies));
        }

        public List<Claim> PageAll(int skip, int take)
        {
            var claimProxies = UnitOfWork.Connection
                .Query<Claim>("SELECT ClaimId, UserId, ClaimType, ClaimValue FROM Claim OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY", param: new { Skip = skip, Take = take }, transaction: UnitOfWork.Transaction)
                .Select(x => new ClaimProxy(UnitOfWork) { ClaimId = x.ClaimId, UserId = x.UserId, ClaimType = x.ClaimType, ClaimValue = x.ClaimValue });
            return new List<Claim>(claimProxies);
        }

        public Task<List<Claim>> PageAllAsync(int skip, int take)
        {
            var claimProxies = UnitOfWork.Connection
                .Query<Claim>("SELECT ClaimId, UserId, ClaimType, ClaimValue FROM Claim OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY", param: new { Skip = skip, Take = take }, transaction: UnitOfWork.Transaction)
                .Select(x => new ClaimProxy(UnitOfWork) { ClaimId = x.ClaimId, UserId = x.UserId, ClaimType = x.ClaimType, ClaimValue = x.ClaimValue });
            return Task.FromResult<List<Claim>>(new List<Claim>(claimProxies));
        }

        public Claim FindById(object id)
        {
            return UnitOfWork.Connection
                .Query<Claim>("SELECT ClaimId, UserId, ClaimType, ClaimValue FROM Claim WHERE ClaimId = @ClaimId", param: new { ClaimId = id }, transaction: UnitOfWork.Transaction)
                .Select(x => new ClaimProxy(UnitOfWork) { ClaimId = x.ClaimId, UserId = x.UserId, ClaimType = x.ClaimType, ClaimValue = x.ClaimValue })
                .FirstOrDefault();
        }

        public Task<Claim> FindByIdAsync(object id)
        {
            return Task.FromResult<Claim>(UnitOfWork.Connection
                .Query<Claim>("SELECT ClaimId, UserId, ClaimType, ClaimValue FROM Claim WHERE ClaimId = @ClaimId", param: new { ClaimId = id }, transaction: UnitOfWork.Transaction)
                .Select(x => new ClaimProxy(UnitOfWork) { ClaimId = x.ClaimId, UserId = x.UserId, ClaimType = x.ClaimType, ClaimValue = x.ClaimValue })
                .FirstOrDefault());
        }

        public void Add(Claim entity)
        {
            entity.ClaimId = UnitOfWork.Connection.ExecuteScalar<int>(
                "INSERT INTO Claim(UserId, ClaimType, ClaimValue VALUES(@UserId, @ClaimType, @ClaimValue)",
                param: new { UserId = entity.UserId, ClaimType = entity.ClaimType, ClaimValue = entity.ClaimValue }, 
                transaction: UnitOfWork.Transaction);
        }

        public void Update(Claim entity)
        {
            UnitOfWork.Connection.Execute(
                "UPDATE Claim SET UserId = @UserId, ClaimType = @ClaimType, ClaimValue = @ClaimValue WHERE ClaimId = @ClaimId",
                param: new { ClaimId = entity.ClaimId, UserId = entity.UserId, ClaimType = entity.ClaimType, ClaimValue = entity.ClaimValue },
                transaction: UnitOfWork.Transaction);
        }

        public void Remove(Claim entity)
        {
            UnitOfWork.Connection.Execute(
                "DELETE FROM Claim WHERE ClaimId = @ClaimId",
                param: new { ClaimId = entity.ClaimId },
                transaction: UnitOfWork.Transaction);
        }
    }
}
