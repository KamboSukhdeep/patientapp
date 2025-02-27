using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientApp.UseCases.Authentication.Queries.LoginAuthenticationQuery;

namespace PatientApp.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginAuthenticationQuery query)
        {
            if (query is null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(query);

            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}
