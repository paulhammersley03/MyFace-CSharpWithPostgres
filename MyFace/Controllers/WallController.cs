using System.Web.Mvc;
using MyFace.DataAccess;
using MyFace.Helpers;
using MyFace.Models.ViewModels;

namespace MyFace.Controllers
{
    [Authorize]
    public class WallController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;


        public WallController(IPostRepository postRepository, IUserRepository userRepository)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
        }

        public ActionResult Index(string username)
        {
            if (username == null)
            {
                username = User?.Identity?.Name;
            }
            var user = userRepository.Login(username);
            var posts = postRepository.GetPostsOnWall(username);
            var viewModel = new WallViewModel(posts, username);

            viewModel.firstname = user.firstname;
            viewModel.surname = user.surname;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult NewWall(WallViewModel wallViewModel)
        {
            var username = User?.Identity?.Name; ;
            postRepository.CreatePost(new Post() { post_content = wallViewModel.NewPost, recipient = wallViewModel.OwnerUsername, sender = username });
            return RedirectToAction("Index", new { username = wallViewModel.OwnerUsername });
        }

        [HttpPost]
        public ActionResult RemoveWall(WallViewModel wallViewModel)
        {
            postRepository.DeletePost(new Post { post_id = wallViewModel.post_id });
            return RedirectToAction("Index", new { username = wallViewModel.OwnerUsername, fullname = wallViewModel.firstname + wallViewModel.surname });
            //if user is logged in and viewing own wall - delete post_id
            //or user is sender - delete post
            //else - computer says no

        }
    }
}