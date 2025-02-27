using MediatR;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Commands.DeletePatientCommand
{
    public class DeletePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
    }
}
