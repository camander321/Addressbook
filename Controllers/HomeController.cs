using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
          return View("Index");
        }
        
        [HttpPost("/")]
        public ActionResult AddNew()
        {
          string name = Request.Form["name"];
          if (name.Length > 0)
          {
            Address address = new Address(
              Request.Form["address"],
              Request.Form["city"],
              Request.Form["state"],
              Request.Form["zip"]
            );
            
            Contact contact = new Contact (
              name,
              Request.Form["number"],
              address
            );
          }
          return View("Index");
        }
        
        [HttpGet("/list/all")]
        public ActionResult ListAll()
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          model.Add("contacts", Contact.GetAll());
          model.Add("msg", "Showing All Contacts");
          return View("List", model);
        }
        
        [HttpGet("/new")]
        public ActionResult ContactForm()
        {
          return View("ContactForm");
        }
    }
}
