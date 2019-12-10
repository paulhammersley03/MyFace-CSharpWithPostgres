using System.Web.Mvc;
using MyFace.DataAccess;
using BCrypt;

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

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.password);

            user.password = hashedPassword;

            userRepository.SignUp(user);
            return RedirectToAction("Index", "UserList");
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            //Redirecting to Login page after deleting Session
            return RedirectToAction("Home/Index.cshtml");
        }
    }
}