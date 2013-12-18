using System.Web.Security;

namespace SimpleBlog.Infrastructure
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string login, string password)
        {
            var result = FormsAuthentication.Authenticate(login, password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(login, false);
            }
            return result;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}