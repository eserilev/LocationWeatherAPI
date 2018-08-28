using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WincChallenge.Models;
using WincChallenge.Respository;

namespace WincChallenge.Controllers
{
    public class LocationController : ApiController
    {
        private readonly LocationRepository repository;

        public LocationController(LocationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> FetchLocation([FromUri]Int32 Id)
        {
            LocationModel location;
            try
            {
                location = await repository.GetById(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(location);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateLocation([FromBody]LocationModel location)
        {
            try
            {
                await repository.Create(location);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(location);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteLocation([FromUri]LocationModel location)
        {
            try
            {
                await repository.Delete(location);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(location);
        }

        [Route("api/location/{id}/weather")]
        [HttpGet]
        public async Task<IHttpActionResult> FetchWeather([FromUri]Int32 Id)
        {
            WeatherModel w;
            try
            {
                w = await repository.GetWeather(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(w);
        }
    }
}
