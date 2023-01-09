using API_Assesment.Data;
using API_Assesment.Models;
using API_Assesment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Services
{
    public class RoleTypeServices : RepositoryServices<RoleType>, IRoleTypeService
    {
        #region Constructor
        public RoleTypeServices(ApplicationDbContext Db) : base(Db)
        {
            _db = Db;
        }
        #endregion

        #region Private Variables

        private ApplicationDbContext _db;

        #endregion

        public async Task<RoleType> Update(RoleType entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
