using API_Assesment.Models;
using API_Assesment.Models.RequestModels;
using API_Assesment.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API_Assesment.Services.Interfaces
{
    public interface IUserService : IRepository<UserDetails>
    {
        Task<UserDetails> Update(UserDetails entity);
        Task<FullUserDetailsResponseModel> GetByEmail(string filter);
        bool EmailValidation(string email);
    }
}
