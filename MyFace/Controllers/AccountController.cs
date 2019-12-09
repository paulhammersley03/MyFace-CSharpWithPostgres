using System.Web.Mvc;
using MyFace.DataAccess;

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
        public ActionResult SignUp(User loginViewModel)
        {
            userRepository.SignUp(loginViewModel);
            return RedirectToAction("Index", "UserList");
        }
    }
}