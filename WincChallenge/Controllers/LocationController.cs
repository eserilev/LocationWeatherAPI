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
        public IHttpActionResult FetchLocation([FromUri]Int32 Id)
        {
            LocationModel location;
            try
            {
                location = repository.GetById(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(location);
        }

        [HttpPost]
        public IHttpActionResult CreateLocation([FromBody]LocationModel location)
        {
            try
            {
                repository.Create(ref location);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(location);
        }

        [HttpDelete]
        public IHttpActionResult DeleteLocation([FromUri]LocationModel location)
        {
            try
            {
                repository.Delete(location);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(location);
        }
    }
}
