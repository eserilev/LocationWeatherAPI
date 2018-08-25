using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WincChallenge.Models;
using WincChallenge.DAL;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

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

        public async Task<WeatherModel> GetWeather(LocationModel entity)
        {
            WeatherModel w;
            using (var http = new HttpClient())
            {
                w = await (await http.GetAsync(@"http://api.openweathermap.org/data/2.5/weather?zip=" +
                    entity.Zipcode + ",us&APPID=" + Properties.Settings.Default.OpenWeatherApiKey)).Content.ReadAsAsync<WeatherModel>();
                //w = JsonConvert.DeserializeObject<WeatherModel>(jsonResponse.ToString());
            }
            return w;
        }
    }
}