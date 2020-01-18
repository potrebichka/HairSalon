using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HairSalonContext _db;
        public AppointmentsController (HairSalonContext db)
        {
            _db = db;
        }
        public ActionResult Create(int id)
        {
            Stylist currentStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            List<Client> clients = _db.Clients.Where(client => client.StylistId == id).ToList();
            ViewBag.ClientList = new SelectList(clients, "ClientId", "Name");
            ViewBag.Stylist = currentStylist;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return RedirectToAction("Index", new {id = appointment.StylistId});
        }
    }
}