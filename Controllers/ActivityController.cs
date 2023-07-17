using Microsoft.AspNetCore.Mvc;
using System;
using ActivityTracker.Models;

namespace ActivityTracker.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ActivityController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var activites = _db.Activities.ToList();

            if (activites == null)
            {
                return NotFound();
            }

            return View(activites);
        }
    }
}
