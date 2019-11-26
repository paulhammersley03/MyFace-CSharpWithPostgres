using System.Web.Mvc;
using MyFace.DataAccess;
using MyFace.Helpers;
using MyFace.Middleware;
using MyFace.Models.ViewModels;

namespace MyFace.Controllers
{
    [BasicAuthentication]
    public class UserListController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserListController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var username = AuthenticationHelper.ExtractUserNameAndPassword(Request).Username;
            var allUsers = userRepository.GetAllUsers();
            var listOfUsers = new UserListViewModel(username, allUsers);

            return View(listOfUsers);
        }
    }
}