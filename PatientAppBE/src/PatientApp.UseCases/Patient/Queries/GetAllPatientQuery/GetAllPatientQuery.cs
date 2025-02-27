using MediatR;
using PatientApp.DTO;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Queries.GetAllPatientQuery
{
    public class GetAllPatientQuery : IRequest<BaseResponse<IEnumerable<PatientDto>>>
    {

    }
}
