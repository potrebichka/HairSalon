using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
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
        public ActionResult Index(int id)
        {
            Stylist currentStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            List<Appointment> appointments = _db.Appointments.Where(app => app.StylistId == id).Include(app => app.Stylist).Include(app => app.Client).ToList();
            ViewBag.Stylist = currentStylist;
            return View(appointments);
        }
        public ActionResult Create(int id)
        {
            Stylist currentStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            List<Client> clients = _db.Clients.Where(client => client.StylistId == id).ToList();
            ViewBag.ClientId = new SelectList(clients, "ClientId", "Name");
            ViewBag.Stylist = currentStylist;
            ViewBag.Failed = false;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            List<Appointment> appointments = _db.Appointments.Where(app => app.StylistId == appointment.StylistId).ToList();
            bool flag = false;
            for(int i = 1; i < appointments.Count; i++)
            {
                if ((appointment.Time.Add(new TimeSpan(-1,0,0)) <= appointments[i].Time) && (appointment.Time.Add(new TimeSpan(1,0,0)) > appointments[i].Time))
                {
                    flag = true;
                    break;
                }
            }
            ViewBag.Failed = false;
            if (flag)
            {
                ViewBag.Failed = true;
                Stylist currentStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == appointment.StylistId);
                List<Client> clients = _db.Clients.Where(client => client.StylistId == appointment.StylistId).ToList();
                ViewBag.ClientId = new SelectList(clients, "ClientId", "Name");
                ViewBag.Stylist = currentStylist;
                return View("Create");
            }
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return RedirectToAction("Index", new {id = appointment.StylistId});
        }
        public ActionResult Details(int id)
        {
            Appointment thisAppointment = _db.Appointments.Include(app => app.Stylist).Include(app => app.Client).FirstOrDefault(app => app.AppointmentId == id);
            return View(thisAppointment);
        }
        public ActionResult Edit (int id)
        {
            Appointment thisAppointment = _db.Appointments.FirstOrDefault(app => app.AppointmentId == id);
            List<Stylist> stylists = _db.Stylists.ToList();
            List<Client> clients = _db.Clients.ToList();
            ViewBag.StylistId = new SelectList(stylists, "StylistId", "Name");
            ViewBag.ClientId = new SelectList(clients, "ClientId", "Name");
            return View(thisAppointment);
        }
        [HttpPost]
        public ActionResult Edit (Appointment appointment)
        {
             _db.Entry(appointment).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", new {id = appointment.AppointmentId});
        }
        public ActionResult Delete(int id)
        {
             Appointment thisAppointment = _db.Appointments.Include(app => app.Stylist).Include(app => app.Client).FirstOrDefault(app => app.AppointmentId == id);
            return View(thisAppointment);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment thisAppointment = _db.Appointments.FirstOrDefault(app => app.AppointmentId == id);
            _db.Appointments.Remove(thisAppointment);
            _db.SaveChanges();
            return RedirectToAction("Index", new {id = thisAppointment.StylistId});
        }
    }
}