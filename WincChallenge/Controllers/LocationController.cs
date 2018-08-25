using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    }
}
