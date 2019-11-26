using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFace.Helpers
{
    public class UserNameAndPassword
    {
        public string Username { get; }
        public string Password { get; }

        public UserNameAndPassword(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

    public  static class AuthenticationHelper
    {
        public static UserNameAndPassword ExtractUserNameAndPassword(HttpRequestBase request)
        {

            var auth = request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(auth))
            {
                var cred = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
                return new UserNameAndPassword(cred[0], cred[1]);
            }

            return null;
        }

}
}