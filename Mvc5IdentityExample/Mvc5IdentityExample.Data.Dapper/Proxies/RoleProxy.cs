using Mvc5IdentityExample.Data.Dapper.Repositories;
using Mvc5IdentityExample.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Mvc5IdentityExample.Data.Dapper.Proxies
{
    public class RoleProxy : Role
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserRepository _userRepository;
        private ICollection<User> _users;

        internal RoleProxy(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.UserRepository as UserRepository;
        }

        public override ICollection<User> Users
        {
            get { return _users ?? (_users = _userRepository.FindByRole(this)); }
            set
            {
                if (value != null)
                {
                    var userProxies = value.Select(x => _userRepository.GetUserProxy(x));
                    _users = new List<User>(userProxies);
                }
                else
                {
                    _users = value;
                }
            }
        }
    }
}
