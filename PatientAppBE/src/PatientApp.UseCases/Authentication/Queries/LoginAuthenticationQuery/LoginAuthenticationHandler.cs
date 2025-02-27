using AutoMapper;
using MediatR;
using PatientApp.DTO;
using PatientApp.Interface.Common;
using PatientApp.Interface.Persistence;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Authentication.Queries.LoginAuthenticationQuery
{
    public class LoginAuthenticationHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginAuthenticationQuery, BaseResponse<UserDto>>
    {

        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        public async Task<BaseResponse<UserDto>> Handle(LoginAuthenticationQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<UserDto>();

            try
            {
                var isValidated =  _unitOfWork.Users.ValidateUser(request.UserName, request.Password);

                if (isValidated)
                {
                    var token = _jwtTokenGenerator.GenerateToken(request.UserName);

                    response.Data = new UserDto { Token = token, UserId = 12, Email = request.UserName }; // just a mock data
                    response.Succcess = true;
                    response.Message = "Login successful";
                }
                else
                {
                    response.Succcess = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
