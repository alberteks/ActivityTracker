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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id, Name, Date")] Activity activity)
        {
            _db.Add(activity);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var activity = _db.Activities.FirstOrDefault(a => a.Id == id);
                return View(activity);
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Name, Date")] Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            _db.Update(activity);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var activity = (_db.Activities.FirstOrDefault(a=>a.Id == id));
            return View(activity);
        }
        [HttpPost]
        public IActionResult Delete(int id, [Bind("Id, Name, Date")] Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }
            _db.Remove(activity);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
