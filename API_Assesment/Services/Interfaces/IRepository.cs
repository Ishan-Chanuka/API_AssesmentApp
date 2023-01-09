using API_Assesment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API_Assesment.Services.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> filter = null, bool track = true);
        Task Remove(T entity);
        Task Save();
    }
}
