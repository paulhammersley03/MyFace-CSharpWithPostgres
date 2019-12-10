using System.Web.Mvc;
using MyFace.Helpers;
using MyFace.DataAccess;

namespace MyFace.Middleware
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var req = filterContext.HttpContext.Request;
            var userNameAndPassword = AuthenticationHelper.ExtractUsernameAndPassword(req);

            if (userNameAndPassword != null)
            {
                var userRepository = new UserRepository();
                var user = userRepository.Login(userNameAndPassword.Username);
                if (user != null)
                {
                    if (user.password.StartsWith("$2a$"))
                    {
                        bool validPassword = BCrypt.Net.BCrypt.Verify(userNameAndPassword.Password, user.password);
                        if (validPassword) return;
                    }
                    else if (userNameAndPassword.Password == user.password)
                    {
                        return;
                    }
                }
            }
            const string realm = "MyFace";

            filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", $"Basic realm=\"{realm}\"");
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}