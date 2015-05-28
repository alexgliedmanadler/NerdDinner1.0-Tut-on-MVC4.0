using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NerdDinner1._4.Models;
using PagedList;


namespace NerdDinner1._4.Controllers
{
    public class DinnersController : Controller
    {
        // dinnerRepository global
        private NerdDinnerContext db = new NerdDinnerContext(); 
        //
        // GET: /Dinners/

        private const int pageSize = 25;
        public ActionResult Index(int? page)
        {
            int pageIndex = page ?? 1;
            //var dinners = dinnerRepository.FindUpcomingDinners().ToList();
            var dinners = db.Dinners.OrderBy(d => d.EventDate);
            return View(dinners.ToPagedList(pageIndex, pageSize));
        }
        //
        // GET: /Dinners/Details/2

        public ActionResult Details(int id = 0)
        {
            Dinner dinner = db.Dinners.Find(id);
            if (dinner == null)
            {
                return HttpNotFound();
            }
            return View(dinner);
        }

        //
        // GET: /Dinners/Edit/2
        public ActionResult Edit(int id)
        {
            Dinner dinner = db.Dinners.Find(id);

            return View(new DinnerFormViewModel(dinner));
        }

        //
        // POST: /Dinners/Edit/2

        [HttpPost]
        public ActionResult Edit(Dinner dinner)
        {

          //  string[] allowedProperties = new[]{ "Title", "Description", 
          //      "ContactPhone", "Address", 
          //      "EventDate", "Latitude", 
          //      "Longitude"};
          //  UpdateModel(dinner, allowedProperties);           //  Can pass an allowedProperties to only update certain values
          //  check for an equivilant with db as opposed to context.
            try
            {
                if (dinner == null)
                {
                    return HttpNotFound();
                }
                /*if(!dinner.IsHostedBy(User.Identity.Name)) {
                    return View("InvalidOwner");
                }*/
                if (ModelState.IsValid)
                {
                    db.Entry(dinner).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                foreach (var issue in dinner.GetRuleViolations())
                    ModelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
                ViewData["countries"] = new SelectList(PhoneValidator.Countries, dinner.Country);
            }
            return View(new DinnerFormViewModel(dinner));
        }

        // 
        // HTTP GET: /Dinners/Delete/1 
        public ActionResult Delete(int id = 0)
        {
            Dinner dinner = db.Dinners.Find(id);
            if (dinner == null)
                return HttpNotFound();
            return View(dinner);
        }

        //
        // HTTP POST: /Dinners/Delete/1
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Dinner dinner = db.Dinners.Find(id);

            if (dinner == null)
                return HttpNotFound();

            db.Dinners.Remove(dinner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // 
        // GET: /Dinners/Create
        public ActionResult Create()
        {
            Dinner dinner = new Dinner()
            {
                EventDate = DateTime.Now.AddDays(14)
            };
            return View(new DinnerFormViewModel(dinner));
        }

        // 
        // POST: /Dinners/Create
        [HttpPost] //add [Authorize]
        public ActionResult Create(Dinner dinner)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(dinner).State = EntityState.Modified;
                    //UpdateModel(dinner);
                    dinner.HostedBy = "LoggedInUser"; //change to 
                    /*RSVP rsvp = new RSVP();
                    rsvp.AttendeeName = User.Identity.Name;

                    dinner.RSVPs = new List<RSVP>();
                    dinner.RSVPs.Add(rsvp);*/

                    db.Dinners.Add(dinner);
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = dinner.DinnerID });
                }
                catch
                {
                    //ModelState.AddRuleViolations(dinner.GetRuleViolations());
                }
            }
            return View(new DinnerFormViewModel(dinner));
        }

    }
}