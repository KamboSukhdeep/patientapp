using MediatR;
using PatientApp.DTO;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Authentication.Queries.LoginAuthenticationQuery
{
    public class LoginAuthenticationQuery : IRequest<BaseResponse<UserDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
