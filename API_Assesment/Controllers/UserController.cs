using API_Assesment.Data;
using API_Assesment.Models;
using API_Assesment.Models.RequestModels;
using API_Assesment.Models.ResponseModels;
using API_Assesment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Constructor

        public UserController(IConverterService ConverterService, IUserService UserService)
        {
            _converterService = ConverterService;
            _userService = UserService;
        }
        #endregion

        #region Private variables

        private readonly IConverterService _converterService;
        private readonly IUserService _userService;

        #endregion



        [HttpGet]
        [Authorize]
        [Route("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserDetailsResponseModel>>> GetAllUsers()
        {
            IEnumerable<UserDetails> users = await _userService.GetAll();
            IEnumerable<UserDetailsResponseModel> response = _converterService.UsersIntoResponse(users);

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FullUserDetailsResponseModel>>> GetUserByEmail(string email)
        {
            if (_userService.EmailValidation(email) == false)
                return BadRequest();
            else
            {
                FullUserDetailsResponseModel users = await _userService.GetByEmail(email);

                return Ok(users);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("AddUsers")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateUserDetailsRequestModel>> AddUsers([FromBody] CreateUserDetailsRequestModel entity) 
        {
            if (_userService.EmailValidation(entity.Email) == false)
                return BadRequest();
            else
            {
                UserDetails request = _converterService.CreateUserReqIntoUser(entity);
                await _userService.Create(request);

                var result = await _userService.GetAll();

                return Ok(result);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] UpdateUserDetailsRequestModel entity)
        {
            if (_userService.EmailValidation(entity.Email) == false)
                return BadRequest();
            else
            {
                UserDetails request = _converterService.UpdateUserReqIntoUser(entity);
                await _userService.Update(request);

                var result = await _userService.GetAll();

                return Ok(result);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var entity = await _userService.GetById(l => l.UserID == Id);
            await _userService.Remove(entity);

            IEnumerable<UserDetails> users = await _userService.GetAll();
            IEnumerable<UserDetailsResponseModel> response = _converterService.UsersIntoResponse(users);

            return Ok(response);
        }
    }
}
