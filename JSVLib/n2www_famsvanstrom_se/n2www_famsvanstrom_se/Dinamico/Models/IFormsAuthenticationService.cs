namespace Dinamico.Models
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
        void SignOut(string returnUrl);
    }
}