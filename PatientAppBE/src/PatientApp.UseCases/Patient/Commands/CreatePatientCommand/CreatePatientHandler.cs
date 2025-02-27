using AutoMapper;
using MediatR;
using PatientApp.Interface.Persistence;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Commands.CreatePatientCommand
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var patient = _mapper.Map<Domain.Entities.Patient>(command);
                response.Data = await _unitOfWork.Patients.InsertAsync(patient);

                if (response.Data)
                {
                    response.Succcess = true;
                    response.Message = "Create succeed!";
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
