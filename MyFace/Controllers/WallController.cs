using System.Web.Mvc;
using MyFace.DataAccess;
using MyFace.Helpers;
using MyFace.Models.ViewModels;
using MyFace.DataAccess;

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
        public ActionResult NewWave(WallViewModel wallViewModel)
        {
            var username = User?.Identity?.Name; ;
            postRepository.CreatePost(new Post() { post_content = wallViewModel.OwnerUsername + " sent a 👋", recipient = wallViewModel.OwnerUsername, sender = username });
            return RedirectToAction("Index", new { username = wallViewModel.OwnerUsername });
        }

        [HttpPost]
        public ActionResult RemoveWall(WallViewModel wallViewModel)
        {
            postRepository.DeletePost(new Post { post_id = wallViewModel.post_id });
            return RedirectToAction("Index", new { username = wallViewModel.OwnerUsername });
        }

        [HttpPost]
        public ActionResult AddLike(WallViewModel wallViewModel)
        {
            postRepository.AddLike(new Post { post_id = wallViewModel.post_id });
            return RedirectToAction("Index", new { username = wallViewModel.OwnerUsername });
        }

        [HttpPost]
        public ActionResult AddDislike(WallViewModel wallViewModel)
        {
            postRepository.AddDislike(new Post { post_id = wallViewModel.post_id });
            return RedirectToAction("Index", new { username = wallViewModel.OwnerUsername });
        }
    }
}