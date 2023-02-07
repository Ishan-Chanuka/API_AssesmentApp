using API_Assesment.Models.RequestModels;
using API_Assesment.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidationsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Constructor

        public LoginController(IConverterService ConverterService, ILoginService LoginService)
        {
            _converterService = ConverterService;
            _loginService = LoginService;
        }

        #endregion

        #region

        private readonly IConverterService _converterService;
        private readonly ILoginService _loginService;

        #endregion

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] LoginRequestModel entity)
        {
            if (EmailValidator.EmailValidation(entity.Email) == false)
                return BadRequest(new { message = "Email or Password is incorrect" });
            else
            {
                string encryptedPass = _converterService.PasswordEncription(entity.Password);
                var request = new LoginRequestModel
                {
                    Email = entity.Email,
                    Password = encryptedPass
                };

                var response =  _loginService.Login(request);

                if (response.Email == null || string.IsNullOrEmpty(response.Token))
                {
                    return BadRequest(new { message = "Email or Password is incorrect" });
                }

                return Ok(response);
            }
        }
    }
}
