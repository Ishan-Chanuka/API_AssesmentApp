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
    public class StatusController : ControllerBase
    {
        #region Constructor
        public StatusController(IConverterService ConverterService, IStatusService StatusService)
        {
            _converterService = ConverterService;
            _statusService = StatusService;
        }
        #endregion

        #region Private variables

        private readonly IConverterService _converterService;
        private readonly IStatusService _statusService;

        #endregion

        [HttpGet]
        [Route("GetAllStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StatusResponseModel>>> GetAllUsers()
        {
            IEnumerable<Status> status = await _statusService.GetAll();
            IEnumerable<StatusResponseModel> response = _converterService.StatusReqIntoResponse(status);

            return Ok(status);
        }

        [HttpPost]
        [Route("AddStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateStatusRequestModel>> AddUsers([FromBody] CreateStatusRequestModel entity)
        {
            Status request = _converterService.CreateStatusReqIntoStatus(entity);
            await _statusService.Create(request);

            var result = await _statusService.GetAll();

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] UpdateStatusRequestModel entity)
        {
            Status request = _converterService.UpdateStatusReqIntoStatus(entity);
            await _statusService.Update(request);

            var result = await _statusService.GetAll();

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var entity = await _statusService.GetById(l => l.StatusID == Id);
            await _statusService.Remove(entity);

            IEnumerable<Status> status = await _statusService.GetAll();
            IEnumerable<StatusResponseModel> response = _converterService.StatusReqIntoResponse(status);

            return Ok(response);
        }
    }
}
