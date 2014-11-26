using System;
using System.Collections.Generic;
using System.Web.Security;
using MyLib.Extensions;
using N2;
using N2.Security.Items;

namespace MyLib.Security
{
    public class MyContentMembershipProvider : N2.Security.ContentMembershipProvider
    {

        public MembershipUser GetUser(Guid providerUserKey, bool userIsOnline)
        {
            N2.Security.Items.UserList userContainer = Bridge.GetUserContainer(false);
            if (userContainer == null)
                return null;

            //IList<ContentItem> users = Bridge.Finder.Where
            //    .Type.Eq(typeof(User))
            //    .And.Parent.Eq(userContainer)
            //    .Select();
            IList<User> users = Bridge.GetUsers("", 0, 200);

            foreach (N2.Security.Items.User u in users)
            {
                if (u.Comment == providerUserKey.ToString())
                {
                    if (userIsOnline)
                    {
                        u.LastActivityDate = DateTime.Now; // JH
                        Bridge.Save(u);
                    }
                    return u.GetMembershipUser(Name);
                }
            }
            return null;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotSupportedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var u = Bridge.GetUser(username);
            if (u != null)
                return u.GetMembershipUser(Name);
            return null;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            var u = Bridge.GetUser(username);
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

            ////return new MembershipUser("MyMembershipProvider", username, providerUserKey, email,
            ////    null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.MinValue);
            var usr = base.CreateUser(username, providerUserKey.ToString(), email, passwordQuestion, passwordAnswer, isApproved, ((Guid)providerUserKey).ToInt(), out status);
            u = Bridge.GetUser(username);
            u.Comment = providerUserKey.ToString();
            //u.Roles.Add("Member");
            Bridge.Save(u);
            return usr;
        }

        public override bool ValidateUser(string username, string password)
        {
            var u = username.ToGuid();
            return base.ValidateUser(username, password);
        }
    }
}
