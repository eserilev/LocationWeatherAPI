using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WincChallenge.Respository
{
    public abstract class EntityBase
    {
        public Int32 Id { get; protected set; }
    }
}