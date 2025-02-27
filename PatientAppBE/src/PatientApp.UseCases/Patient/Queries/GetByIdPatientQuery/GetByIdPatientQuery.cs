using MediatR;
using PatientApp.DTO;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Queries.GetByIdCustomerQuery
{
    public class GetByIdPatientQuery : IRequest<BaseResponse<PatientDto>>
    {
        public int PatientId { get; set; }
    }
}
