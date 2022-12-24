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

    [HttpGet("/appointment/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Appointment thisAppointment = _db.appointment.FirstOrDefault(appointment => appointment.appointment_id == id);
      ViewBag.client = _db.client.FirstOrDefault(client => client.client_id == thisAppointment.client_id);
      return View(thisAppointment);
    }

    [HttpPost("/appointment/delete/{id}")]
    public ActionResult DeleteConfirm(int id)
    {
      Appointment thisAppointment = _db.appointment.FirstOrDefault(appointment => appointment.appointment_id == id);
      _db.appointment.Remove(thisAppointment);
      _db.SaveChanges();
      return Redirect($"/stylists/{thisAppointment.stylist_id}");
    }
  }
}