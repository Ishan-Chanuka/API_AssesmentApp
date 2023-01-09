using API_Assesment.Data;
using API_Assesment.Models;
using API_Assesment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Services
{
    public class StatusServices : RepositoryServices<Status>, IStatusService
    {
        #region Constructor
        public StatusServices(ApplicationDbContext Db) : base(Db)
        {
            _db = Db;
        }
        #endregion

        #region Private variables

        private readonly ApplicationDbContext _db;

        #endregion

        public async Task<Status> Update(Status entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
