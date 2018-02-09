using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using System;
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
    
    [HttpPost("/add")]
    public ActionResult AddNew()
    {
      string msg = "";
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
        msg = "Contact info for '" + name + "' has been successfully added!";
        return View("Confirm", msg);
      }
      msg = "Contact info could not be added!";
      return View("Confirm", msg);
    }
    
    [HttpGet("/list/all")]
    public ActionResult ListAll()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("contacts", Contact.GetAll());
      model.Add("msg", "Showing All Contacts");
      return View("List", model);
    }
    
    [HttpGet("/list/search")]
    public ActionResult Search()
    {
      string searchString = Request.Query["search"];
      List<Contact> contacts = Contact.Search(searchString);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("contacts", contacts);
      model.Add("msg", "Showing Results For '" + searchString + "'");
      return View("List", model);
    }
    
    [HttpGet("/contact/{id}")]
    public ActionResult Detail(int id)
    {
      return View("Detail", Contact.Find(id));
    }
    
    [HttpGet("/new")]
    public ActionResult ContactForm()
    {
      return View("ContactForm");
    }
    
    [HttpGet("/remove/{id}")]
    public ActionResult Removeconfirm(int id)
    {
      string msg = "Contact info for '" + Contact.Find(id).GetName() + "' has been successfully removed!";
      Contact.Remove(id);
      return View("Confirm", msg);
    }
    
    [HttpPost("/remove/all")]
    public ActionResult Clear()
    {
      Contact.Clear();
      string msg = "Contact List Has Been Cleared";
      return View("Confirm", msg);
    }
  }
}
