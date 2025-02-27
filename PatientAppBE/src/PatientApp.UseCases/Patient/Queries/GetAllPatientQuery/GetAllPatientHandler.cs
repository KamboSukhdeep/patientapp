using AutoMapper;
using MediatR;
using PatientApp.DTO;
using PatientApp.Interface.Persistence;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Queries.GetAllPatientQuery
{
    public class GetAllPatientHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllPatientQuery, BaseResponse<IEnumerable<PatientDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<BaseResponse<IEnumerable<PatientDto>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<PatientDto>>();

            try
            {
                var patients = await _unitOfWork.Patients.GetAllAsync();

                if (patients is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<PatientDto>>(patients);
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
