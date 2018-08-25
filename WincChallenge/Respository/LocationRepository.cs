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
                if (l != null)
                {
                    db.Locations.Remove(l);
                    await db.SaveChangesAsync();
                }
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
            WeatherForecast f;
            CurrentWeather c;
            var cache = CacheManager.Connection.GetDatabase();
            using (var http = new HttpClient())
            {
                var cachedWeather = await cache.StringGetAsync(entity.Zipcode.ToString());
                if (cachedWeather.HasValue)
                {
                    var check = JsonConvert.DeserializeObject<WeatherModel>(cachedWeather);
                    var minutes = DateTime.Now.ToUniversalTime().Subtract(check.searchDate).TotalMinutes;
                    if (minutes <= 5)
                    {
                        return check;
                    }
                }
                f = await (await http.GetAsync(@"http://api.openweathermap.org/data/2.5/forecast?zip=" +
                    entity.Zipcode + ",us&APPID=" + Properties.Settings.Default.OpenWeatherApiKey)).Content.ReadAsAsync<WeatherForecast>();

                c = await (await http.GetAsync(@"http://api.openweathermap.org/data/2.5/weather?zip=" +
                    entity.Zipcode + ",us&APPID=" + Properties.Settings.Default.OpenWeatherApiKey)).Content.ReadAsAsync<CurrentWeather>();

                w = new WeatherModel
                {
                    zipCode = entity.Zipcode,
                    currentWeather = c,
                    threeHourForecast = f.list,
                    name = c.name,
                    searchDate = DateTime.Now.ToUniversalTime(),
                };


                await cache.StringSetAsync(entity.Zipcode.ToString(), JsonConvert.SerializeObject(w));
            }
            return w;
        }
    }
}