using Mvc5IdentityExample.Data.Dapper.Repositories;
using Mvc5IdentityExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc5IdentityExample.Data.Dapper.Proxies
{
    public class UserProxy : User
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ClaimRepository _claimRepository;
        private readonly ExternalLoginRepository _externalLoginRepository;
        private readonly RoleRepository _roleRepository;

        internal UserProxy(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _claimRepository = unitOfWork.ClaimRepository as ClaimRepository;
            _externalLoginRepository = unitOfWork.ExternalLoginRepository as ExternalLoginRepository;
            _roleRepository = unitOfWork.RoleRepository as RoleRepository;
        }

        public override ICollection<Claim> Claims
        {
            get
            {
                return base.Claims;
            }
            set
            {
                base.Claims = value;
            }
        }

        public override ICollection<ExternalLogin> Logins
        {
            get
            {
                return base.Logins;
            }
            set
            {
                base.Logins = value;
            }
        }

        public override ICollection<Role> Roles
        {
            get
            {
                return base.Roles;
            }
            set
            {
                base.Roles = value;
            }
        }
    }
}
