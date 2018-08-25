using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WincChallenge.Respository
{
    public interface IRepository<T> where T: EntityBase
    {
        Task<T> GetById(Int32 id);
        Task Create(T entity);
        Task Delete(T entity);
        
    }
}