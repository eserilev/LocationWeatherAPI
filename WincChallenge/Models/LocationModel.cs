using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WincChallenge.Respository;

namespace WincChallenge.Models
{
    public class LocationModel : EntityBase
    {
        public string Name { get; set; }
        public Int32 Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}