using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientApp.UseCases.Patient.Commands.CreatePatientCommand;
using PatientApp.UseCases.Patient.Commands.DeletePatientCommand;
using PatientApp.UseCases.Patient.Commands.UpdatePatientCommand;
using PatientApp.UseCases.Patient.Queries.GetAllPatientQuery;
using PatientApp.UseCases.Patient.Queries.GetAllWithPaginationPatientQuery;
using PatientApp.UseCases.Patient.Queries.GetByIdCustomerQuery;

namespace PatientApp.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PatientController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllPatientQuery());

            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAsync([FromQuery] int patientId)
        {
            var response = await _mediator.Send(new GetByIdPatientQuery() { PatientId = patientId });
            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllWithPagination")]
        public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] GetAllWithPaginationPatientQuery query)
        {
            var response = await _mediator.Send(query);

            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> InsertAsync([FromBody] CreatePatientCommand command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);

            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync([FromBody]UpdatePatientCommand command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);

            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeletePatientCommand command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);

            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}
