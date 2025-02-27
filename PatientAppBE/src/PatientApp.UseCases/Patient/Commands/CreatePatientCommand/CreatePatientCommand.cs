using MediatR;
using PatientApp.UseCases.Common.Base;

namespace PatientApp.UseCases.Patient.Commands.CreatePatientCommand
{
    public class CreatePatientCommand: IRequest<BaseResponse<bool>>
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? InsuranceProvider { get; set; }
        public string? InsurancePolicyNumber { get; set; }
    }
}
