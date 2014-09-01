using System.Web.Mvc;
using SockChat.DAL;

namespace SockChat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to Sock iChat.";

            return View();
        }

        public ActionResult Test() 
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Twitter:@MadManMorgan";

            return View();
        }

        public ActionResult Chat() 
        {
            return View(Message.Get());
        }
    }
}