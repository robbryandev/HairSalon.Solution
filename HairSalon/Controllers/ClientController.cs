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

    [HttpGet("/client/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Client thisClient = _db.client.FirstOrDefault(client => client.client_id == id);
      return View(thisClient);
    }

    [HttpPost("/client/delete/{id}")]
    public ActionResult DeleteConfirm(int id)
    {
      Client thisClient = _db.client.FirstOrDefault(client => client.client_id == id);
      List<Appointment> thisAppointments = _db.appointment.ToList();
      foreach (Appointment appointment in thisAppointments)
      {
        if (appointment.client_id == id)
        {
          _db.appointment.Remove(appointment);
        }
      }
      _db.client.Remove(thisClient);
      _db.SaveChanges();
      return Redirect($"/stylists/{thisClient.stylist_id}");
    }
  }
}