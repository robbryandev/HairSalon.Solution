using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    private readonly HairSalonContext _db;

    public StylistController(HairSalonContext db)
    {
      _db = db;
    }

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> stylists = _db.stylist.ToList();
      ViewBag.stylists = stylists;
      return View();
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Display(int id)
    {
      Stylist thisStylist = _db.stylist.FirstOrDefault(stylist => stylist.stylist_id == id);
      List<Client> clients = _db.client.ToList();
      List<Client> filtered = new List<Client>{};
      foreach (Client client in clients)
      {
        if (client.stylist_id == id)
        {
          filtered.Add(client);
        }
      }
      ViewBag.clients = filtered;
      return View(thisStylist);
    }

    [HttpGet("/stylists/create")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Add(stylist);
      _db.SaveChanges();
      return Redirect("/stylists");
    }

    [HttpGet("/stylists/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Stylist thisStylist = _db.stylist.FirstOrDefault(stylist => stylist.stylist_id == id);
      return View(thisStylist);
    }

    [HttpPost("/stylists/delete/{id}")]
    public ActionResult DeleteConfirm(int id)
    {
      Stylist thisStylist = _db.stylist.FirstOrDefault(stylist => stylist.stylist_id == id);
      List<Client> thisClients = _db.client.ToList();
      foreach (Client client in thisClients)
      {
        if (client.stylist_id == id)
        {
          _db.client.Remove(client);
        }
      }
      _db.stylist.Remove(thisStylist);
      _db.SaveChanges();
      return Redirect("/stylists");
    }
  }
}