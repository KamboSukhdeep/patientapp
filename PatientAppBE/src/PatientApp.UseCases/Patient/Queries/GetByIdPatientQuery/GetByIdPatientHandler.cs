using AutoMapper;
using MediatR;
using PatientApp.DTO;
using PatientApp.Interface.Persistence;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Queries.GetByIdCustomerQuery
{
    public class GetByIdPatientHandler : IRequestHandler<GetByIdPatientQuery, BaseResponse<PatientDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdPatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<PatientDto>> Handle(GetByIdPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PatientDto>();
            try
            {
                var customer = await _unitOfWork.Patients.GetAsync(request.PatientId);
                if (customer is not null)
                {
                    response.Data = _mapper.Map<PatientDto>(customer);
                    response.Succcess = true;
                    response.Message = "Query succeed!";
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
