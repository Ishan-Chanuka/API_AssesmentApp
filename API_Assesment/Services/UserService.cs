using API_Assesment.Data;
using API_Assesment.Models;
using API_Assesment.Models.RequestModels;
using API_Assesment.Models.ResponseModels;
using API_Assesment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API_Assesment.Services
{
    public class UserService : RepositoryServices<UserDetails>, IUserService
    {
        #region Constructor
        public UserService(ApplicationDbContext Db) : base(Db)
        {
            _db = Db;
        }
        #endregion

        #region Private variables

        private readonly ApplicationDbContext _db;

        #endregion

        public async Task<UserDetails> Update(UserDetails entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<FullUserDetailsResponseModel> GetByEmail(string filter)
        {
            var response = (from t1 in _db.UserDetails
                            join t2 in _db.RoleType on t1.RoleType equals t2.RoleID
                            join t3 in _db.Status on t1.Status equals t3.StatusID
                            where t1.Email == filter
                            select new FullUserDetailsResponseModel
                            {
                                UserID = t1.UserID.ToString(),
                                FirstName = t1.FirstName,
                                LastName = t1.LastName,
                                Email = t1.Email,
                                Password = t1.Password,
                                DateofBirth = t1.DateofBirth,
                                RoleType = t1.RoleType.ToString(),
                                RoleName = t2.RoleName,
                                Status = t1.Status.ToString(),
                                StatusName = t3.StatusName,
                                CreatedAt = t1.CreatedAt.ToString(),
                                ModifiedAt = t1.ModifiedAt.ToString()
                            }).FirstOrDefault();

            return response;
        }

        public bool EmailValidation(string email)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

            if (Regex.IsMatch(email, pattern))
                return true;
            else
                return false;
        }
    }
}
