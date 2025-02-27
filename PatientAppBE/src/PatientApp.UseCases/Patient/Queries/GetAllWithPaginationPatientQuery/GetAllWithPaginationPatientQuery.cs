using MediatR;
using PatientApp.DTO;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Queries.GetAllWithPaginationPatientQuery
{
    public class GetAllWithPaginationPatientQuery : IRequest<BaseResponsePagination<IEnumerable<PatientDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
