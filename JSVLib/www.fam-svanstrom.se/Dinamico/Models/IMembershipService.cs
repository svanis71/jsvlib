using System.Web.Security;

namespace Dinamico.Models
{
    public interface IMembershipService
    {
        bool ValidateUser(string userName, string openId);
        MembershipCreateStatus CreateUser(string userName, string password,
                                          string email, string OpenID);
        MembershipUser GetUser(string OpenID);
        int MinPasswordLength { get; }
    }
}