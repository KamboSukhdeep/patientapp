using FluentValidation;

namespace PatientApp.UseCases.Patient.Commands.CreatePatientCommand
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(200).WithMessage("First Name is required");
            RuleFor(x => x.LastName).MaximumLength(200);
            RuleFor(x => x.Gender).NotEmpty().NotNull().WithMessage("First Name is required");
            RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage("First Name is required");
            RuleFor(x => x.PhoneNumber).MaximumLength(10);
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required");
            RuleFor(x => x.InsuranceProvider).MaximumLength(200);
            RuleFor(x => x.InsurancePolicyNumber).MaximumLength(20);
        }
    }
}
