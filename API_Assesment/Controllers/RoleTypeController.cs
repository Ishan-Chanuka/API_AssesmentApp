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
    [Authorize]
    public class RoleTypeController : ControllerBase
    {
        #region Controller
        public RoleTypeController(IConverterService ConverterService, IRoleTypeService RoleTypeService)
        {
            _converterService = ConverterService;
            _roleTypeService = RoleTypeService;
        }
        #endregion

        #region Public Variables

        public readonly IConverterService _converterService;
        public readonly IRoleTypeService _roleTypeService;

        #endregion

        [HttpGet]
        [Route("GetAllRoleTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<RoleTypeResponseModel>>> GetAllUsers()
        {
            IEnumerable<RoleType> roles = await _roleTypeService.GetAll();
            IEnumerable<RoleTypeResponseModel> response = _converterService.RoleTypeIntoResponse(roles);

            return Ok(response);
        }

        [HttpPost]
        [Route("AddRole")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateRoleTypeRequestModel>> AddUsers([FromBody] CreateRoleTypeRequestModel entity)
        {
            RoleType request = _converterService.CreateRoleReqTypeIntoRole(entity);
            await _roleTypeService.Create(request);

            var result = await _roleTypeService.GetAll();

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] UpdateRoleTypeRequestModel entity)
        {
            RoleType request =  _converterService.UpdateRoleTypeReqIntoRole(entity);
            await _roleTypeService.Update(request);

            var response = await _roleTypeService.GetAll();

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var entity = await _roleTypeService.GetById(l => l.RoleID == Id);
            await _roleTypeService.Remove(entity);

            IEnumerable<RoleType> role = await _roleTypeService.GetAll();
            IEnumerable<RoleTypeResponseModel> response = _converterService.RoleTypeIntoResponse(role);

            return Ok(response);
        }
    }
}
