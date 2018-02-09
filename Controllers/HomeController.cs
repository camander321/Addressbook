using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
