using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class AppointmentController : Controller
  {

    private readonly HairSalonContext _db;

    public AppointmentController(HairSalonContext db)
    {
      _db = db;
    }

    [HttpPost("/appointment/{id}/create")]
    public ActionResult CreateSubmit(int id, int client_id, Appointment appointment)
    {
      appointment.stylist_id = id;
      appointment.client_id = client_id;
      _db.Add(appointment);
      _db.SaveChanges();
      return Redirect($"/stylists/{id}");
    }
  }
}