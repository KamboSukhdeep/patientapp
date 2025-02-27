using FluentValidation;
using PatientApp.UseCases.Patient.Queries.GetByIdCustomerQuery;

namespace CleanArchitectrure.Application.UseCases.Customers.Queries.GetByIdCustomerQuery
{
    public class GetByIdPatientValidator: AbstractValidator<GetByIdPatientQuery>
    {
        public GetByIdPatientValidator()
        {
            RuleFor(x => x.PatientId)
                .NotEmpty()
                .NotNull();
        }
    }
}
