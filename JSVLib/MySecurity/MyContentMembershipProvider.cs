using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace MySecurity
{
    public class MyContentMembershipProvider : N2.Security.ContentMembershipProvider
    {
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            var u = Bridge.GetUser(providerUserKey.ToString()); // openid

            if (u != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }
            if (string.IsNullOrEmpty(username))
            {
                status = MembershipCreateStatus.InvalidUserName;
                return null;
            }

            
            //return new MembershipUser("MyMembershipProvider", username, providerUserKey, email,
            //    null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.MinValue);
            return base.CreateUser(providerUserKey.ToString(), password, email, passwordQuestion, passwordAnswer, isApproved, username, out status);
        }

        public override bool ValidateUser(string username, string password)
        {
            return base.ValidateUser(username, password);
        }
    }
}
