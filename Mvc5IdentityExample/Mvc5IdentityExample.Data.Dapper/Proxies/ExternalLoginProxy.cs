using Mvc5IdentityExample.Data.Dapper.Repositories;
using Mvc5IdentityExample.Domain.Entities;

namespace Mvc5IdentityExample.Data.Dapper.Proxies
{
    public class ExternalLoginProxy : ExternalLogin
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserRepository _userRepository;
        private UserProxy _userProxy;

        internal ExternalLoginProxy(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.UserRepository as UserRepository;
        }

        public override User User
        {
            get { return _userProxy ?? (_userProxy = _userRepository.FindProxyById(UserId)); }
            set
            {
                _userProxy = _userRepository.GetUserProxy(value);
                UserId = value.UserId;
            }
        }
    }
}
