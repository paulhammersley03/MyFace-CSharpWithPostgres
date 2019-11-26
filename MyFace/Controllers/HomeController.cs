using System.Web.Mvc;
using MyFace.Middleware;

namespace MyFace.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}