using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MySecurity.Security
{
    public class MyMembershipProvider : System.Web.Security.MembershipProvider
    {
        public MembershipUser CreateUser(string userName, string email, bool isApproved, Guid providerKey, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.Success;
            using(var ent = new WebdbModel())
            {
                if(ent.users.Any(p => p.userName == userName))
                    throw new ApplicationException("Användarnamnet är upptaget.");
                ent.users.AddObject(new users()
                                        {
                                            userName = userName,
                                            email = email,
                                            openId = providerKey.ToString()
                                        });
                ent.SaveChanges();
            }
            return new MembershipUser("MyMembershipProvider", userName, providerKey, email,
                null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.MinValue);
        }

        public bool ValidateUser(string providerKey)
        {
            using(var ent = new WebdbModel())
            {
                return ent.users.Any(u => u.openId == providerKey.ToString());
            }
        }

        public bool DeleteUser(Guid providerKey)
        {
            return true;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            using(var ent = new WebdbModel())
            {
                var key = providerUserKey.ToString();
                var userEnt = ent.users
                    .Where(p => p.openId == key)
                    .Select(p => p)
                    .SingleOrDefault();
                return userEnt != null ? new MembershipUser("MyMembershipProvider", userEnt.userName, userEnt.openId, userEnt.email,
                                          null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now,
                                          DateTime.Now, DateTime.MinValue) : null;
            }
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            using (var ent = new WebdbModel())
            {
                var userEnt = ent.users
                    .Where(p => p.userName == username)
                    .Select(p => p)
                    .SingleOrDefault();
                return userEnt != null ? new MembershipUser("MyMembershipProvider", userEnt.userName, userEnt.openId, userEnt.email,
                                          null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now,
                                          DateTime.Now, DateTime.MinValue) : null;
            }
        }

        #region Not implemented members
        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }


        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override bool EnablePasswordReset
        {
            get { return false; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 1; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 1; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

	#endregion    
    }
}