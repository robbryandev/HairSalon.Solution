using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {

    private readonly HairSalonContext _db;

    public ClientController(HairSalonContext db)
    {
      _db = db;
    }

    [HttpGet("/client/{id}/create")]
    public ActionResult Create(int id)
    {
      ViewBag.stylist = _db.stylist.FirstOrDefault(stylist => stylist.stylist_id == id);
      return View();
    }

    [HttpPost("/client/{id}/create")]
    public ActionResult CreateSubmit(int id, Client client)
    {
      client.stylist_id = id;
      _db.Add(client);
      _db.SaveChanges();
      return Redirect($"/stylists/{id}");
    }
  }
}