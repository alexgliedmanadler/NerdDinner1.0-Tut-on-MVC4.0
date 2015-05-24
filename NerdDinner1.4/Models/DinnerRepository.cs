using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner1._4.Models
{
    public class DinnerRepository
    {
        // IQueryable methods
        public IQueryable<Dinner> FindAllDinners();
        public IQueryable<Dinner> FindUpcomingDinners();
        public Dinner GetDinner(int id);

        // Insert/Delete
        public void Add(Dinner dinner);
        public void Delete(Dinner dinner);

        // Persist data into DB
        public void Save();
    }

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