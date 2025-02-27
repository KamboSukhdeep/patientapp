using AutoMapper;
using MediatR;
using PatientApp.DTO;
using PatientApp.Interface.Persistence;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Queries.GetAllWithPaginationPatientQuery
{
    internal class GetAllWithPaginationPatientHandler : IRequestHandler<GetAllWithPaginationPatientQuery, BaseResponsePagination<IEnumerable<PatientDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWithPaginationPatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponsePagination<IEnumerable<PatientDto>>> Handle(GetAllWithPaginationPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponsePagination<IEnumerable<PatientDto>>();

            try
            {
                var count = await _unitOfWork.Patients.CountAsync();

                var patients = await _unitOfWork.Patients.GetAllWithPaginationAsync(request.PageNumber, request.PageSize);

                if (patients is not null)
                {
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
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
