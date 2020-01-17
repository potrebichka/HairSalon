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
    }
}