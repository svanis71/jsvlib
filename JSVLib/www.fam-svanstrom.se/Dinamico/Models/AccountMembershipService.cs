using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using MyLib.Extensions;
using MyLib.Security;
using N2.Engine;

namespace Dinamico.Models
{
    [Service(typeof(IMembershipService))]
    public class AccountMembershipService : IMembershipService
    {
        private readonly MyContentMembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MyContentMembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider as MyContentMembershipProvider;
        }

        public bool ValidateUser(string userName, string openId)
        {
            return _provider.ValidateUser(userName, openId.ToGuid().ToString());
        }

        public MembershipCreateStatus CreateUser(string userName, string password,
                                                 string email, string OpenID)
        {
            if (String.IsNullOrEmpty(userName)) throw
                new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(email)) throw
                new ArgumentException("Value cannot be null or empty.", "email");

            MembershipCreateStatus status;
            _provider.CreateUser(userName, OpenID.ToGuid().ToString(), email, null, null, true, OpenID.ToGuid(), out status);
            return status;
        }

        public MembershipUser GetUser(string OpenID)
        {
            return _provider.GetUser(StringToGUID(OpenID), true);
        }

        public Guid StringToGUID(string value)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            return new Guid(data);
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

    }
}