using API_Assesment.Data;
using API_Assesment.Models.RequestModels;
using API_Assesment.Models.ResponseModels;
using API_Assesment.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_Assesment.Services
{
    public class LoginService : ILoginService
    {
        #region Constructor

        public LoginService(ApplicationDbContext Db, IConfiguration Configuration)
        {
            _db = Db;
            _secretKey = Configuration.GetValue<string>("ApiSettings:SecretKey");
        }

        #endregion

        #region Private variables

        private readonly ApplicationDbContext _db;
        private string _secretKey;

        #endregion

        public LoginResponseModel Login(LoginRequestModel entity)
        {
            var user = _db.UserDetails.FirstOrDefault(u => u.Email == entity.Email && u.Password == entity.Password);

            if (user == null)
            {
                return new LoginResponseModel()
                {
                    Token = "",
                    Email = null
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),

                Expires = DateTime.UtcNow.AddDays(7),

                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseModel response = new LoginResponseModel()
            {
                Token = tokenHandler.WriteToken(token),
                Email = user.Email
            };

            return response;
        }
    }
}
