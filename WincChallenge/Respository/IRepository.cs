using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WincChallenge.Respository
{
    public interface IRepository<T> where T: EntityBase
    {
        T GetById(Int32 id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        
    }
}