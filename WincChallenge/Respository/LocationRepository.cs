using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WincChallenge.Models;
using WincChallenge.DAL;

namespace WincChallenge.Respository
{
    public class LocationRepository : IRepository<LocationModel>
    {
        public void Create(ref LocationModel entity)
        {
            using (var db = new WincChallengeDbEntities())
            {
                var l = new Location
                {
                    Country = entity.Country,
                    Name = entity.Name,
                    State = entity.State,
                    Zipcode = entity.Zipcode
                };
                db.Locations.Add(l);
                db.SaveChanges();
                entity.Id = l.Id;
            }
        }

        public void Delete(LocationModel entity)
        {
            using (var db = new WincChallengeDbEntities())
            {
                var l = db.Locations.Where(x => x.Id == entity.Id).SingleOrDefault();
                db.Locations.Remove(l);
                db.SaveChanges();
            }
        }


        public LocationModel GetById(int id)
        {
            using (var db = new WincChallengeDbEntities())
            {
                var l = db.Locations.Where(x => x.Id == id).SingleOrDefault();
                if (l == null) return null;
                return new LocationModel
                {
                    Id = l.Id,
                    Country = l.Country,
                    Name = l.Name,
                    State = l.State,
                    Zipcode = l.Zipcode
                };
            }
        }
    }
}