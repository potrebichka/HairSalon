using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;
        public ClientsController (HairSalonContext db)
        {
            _db = db;
        }
        public ActionResult Index(int id)
        {
            List<Client> model = _db.Clients.Where(clients => clients.StylistId == id).ToList();
            Stylist currentStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            ViewBag.Name = currentStylist.Name;
            ViewBag.Id = currentStylist.StylistId;
            return View(model);
        }
        public ActionResult Create(int id)
        {
            Stylist currentStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            ViewBag.Id = currentStylist.StylistId;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index", new {id = client.StylistId});
        }
        public ActionResult Details(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == thisClient.StylistId);
            ViewBag.Name = thisStylist.Name;
            return View(thisClient);
        }
        public ActionResult Edit(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            return View(thisClient);
        }
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", new {id = client.StylistId});
        }
        public ActionResult Delete(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            return View(thisClient);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            _db.Clients.Remove(thisClient);
            _db.SaveChanges();
            return RedirectToAction("Index", new {id = thisClient.StylistId});
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string clientName)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.Name == clientName);
            return View("Results", thisClient);
        }
    }
}