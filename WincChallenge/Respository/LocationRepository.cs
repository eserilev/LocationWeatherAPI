using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WincChallenge.Models;
using WincChallenge.DAL;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WincChallenge.Respository
{
    public class LocationRepository : IRepository<LocationModel>
    {
        public async Task Create(LocationModel entity)
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
                await db.SaveChangesAsync();
                entity.Id = l.Id;
            }
        }

        public async Task Delete(LocationModel entity)
        {
            using (var db = new WincChallengeDbEntities())
            {
                var l = await db.Locations.Where(x => x.Id == entity.Id).SingleOrDefaultAsync();
                db.Locations.Remove(l);
                await db.SaveChangesAsync();
            }
        }


        public async Task<LocationModel> GetById(int id)
        {
            using (var db = new WincChallengeDbEntities())
            {
                var l = await db.Locations.Where(x => x.Id == id).SingleOrDefaultAsync();
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
        
        public WeatherModel GetWeather(LocationModel entity)
        {
            return new WeatherModel();
        }
    }
}