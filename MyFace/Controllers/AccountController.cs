using System.Web.Mvc;
using MyFace.DataAccess;
using BCrypt;
using System.Web.Security;
using System.Web;
using System;
using System.Web.Configuration;

namespace MyFace.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepository;

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult SignUp()
        {
            return View(new User());
        }

        public ActionResult LogIn()
        {
            return View();//Return Blank LogIn Page to Input Login Details
        }

        [HttpPost]//Returns users login details from logIn from above and either gives authentication to use the site or returns an error
        public ActionResult LogIn(User userNameAndPassword)
        {
            var user = userRepository.Login(userNameAndPassword.username);
            if (user != null)
            {
                if (user.password.StartsWith("$2a$"))
                {
                    bool validPassword = BCrypt.Net.BCrypt.Verify(userNameAndPassword.password, user.password);
                    if (validPassword)
                    {
                        FormsAuthentication.RedirectFromLoginPage(user.username, true);
                        return RedirectToAction("Index", "Wall", new { user.username });
                    }
                }
                else if (userNameAndPassword.password == user.password)
                {
                    FormsAuthentication.RedirectFromLoginPage(user.username, true);
                    return RedirectToAction("Index", "Wall", new { user.username });
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(user.username, false);
                    return RedirectToAction("Shared", "Error", new { username = user.username });
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();//on Log Out button click 
            Session.Abandon();//Abandon the current browser session
            FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("LogIn");//Redirect to the login page
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.password);

            user.password = hashedPassword;

            userRepository.SignUp(user);
            return RedirectToAction("Index", "UserList");
        }
    }
}