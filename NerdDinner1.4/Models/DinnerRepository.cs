using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner1._4.Models
{
    /*interface IDinnerRepository
    {
        // IQueryable methods
        IQueryable<Dinner> FindAllDinners();
        IQueryable<Dinner> FindUpcomingDinners();
        Dinner GetDinner(int id);

        // Insert/Delete
        void Add(Dinner dinner);
        void Delete(Dinner dinner);

        // Persist data into DB
        void Save();
    }*/

    public class DinnerRepository
    {
        // Database datacontext
        private NerdDinnerDataContext db = new NerdDinnerDataContext();

        //
        // Queryable methods

        public IQueryable<Dinner> FindAllDinners()
        {
            return db.Dinners;
        }

        public IQueryable<Dinner> FindUpcomingDinners()
        {
            return from dinner in db.Dinners
                   where dinner.EventDate > DateTime.Now
                   orderby dinner.EventDate
                   select dinner;
        }

        public Dinner GetDinner(int id)
        {
            return db.Dinners.SingleOrDefault(d => d.DinnerID == id);
        }

        //
        // Insert/Delete methods

        public void Add(Dinner dinner)
        {
            db.Dinners.InsertOnSubmit(dinner);
        }

        public void Delete(Dinner dinner)
        {
            db.RSVPs.DeleteAllOnSubmit(dinner.RSVPs);
            db.Dinners.DeleteOnSubmit(dinner);
        }

        //
        // Persistence

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}