using System;

namespace Mvc5IdentityExample.Domain.Entities
{
    public class Claim
    {
        private User _user;

        #region Scalar Properties
        public virtual int ClaimId { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
        #endregion

        #region Navigation Properties
        public virtual User User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _user = value;
                UserId = value.UserId;
            }
        }
        #endregion
    }
}
