using API_Assesment.Data;
using API_Assesment.Models;
using API_Assesment.Models.ResponseModels;
using API_Assesment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API_Assesment.Services
{
    public class RepositoryServices<T> : IRepository<T> where T : class
    {
        #region Constructor
        public RepositoryServices(ApplicationDbContext Db)
        {
            _db = Db;
            _dbSet = _db.Set<T>();
        }
        #endregion

        #region Private variables

        private readonly ApplicationDbContext _db;

        #endregion

        internal DbSet<T> _dbSet;

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await Save();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = _dbSet;

            return await query.ToListAsync();
        }

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            await Save();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> filter = null, bool track = true)
        {
            IQueryable<T> query = _dbSet;

            if (!track)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
