using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner1._4.Models;
using PagedList;


namespace NerdDinner1._4.Controllers
{
    public class DinnersController : Controller
    {
        // dinnerRepository global
        DinnerRepository dinnerRepository = new DinnerRepository();
        private NerdDinnerDataContext db = new NerdDinnerDataContext(); 
        //
        // GET: /Dinners/

        public ActionResult Index(int? page)
        {
            int pageIndex = page ?? 1;
            //var dinners = dinnerRepository.FindUpcomingDinners().ToList();
            var dinners = db.Dinners.OrderBy(d => d.EventDate);
            return View(dinners.ToPagedList(pageIndex, 25));
            //return View("Index", dinners);
        }
        //
        // GET: /Dinners/Details/2

        public ActionResult Details(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);
            if (dinner == null)
                return View("NotFound");
            else
                return View(dinner);
        }
    }
}