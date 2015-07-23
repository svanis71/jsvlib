using System.Web.Security;

namespace Dinamico.Models
{
    public interface IMembershipService
    {
        //bool ValidateUser(string userName, string openId);
        //MembershipCreateStatus CreateUser(string userName, string password,
        //                                  string email, string OpenID);
        //MembershipUser GetUser(string OpenID);
        //int MinPasswordLength { get; }
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);

    }
}