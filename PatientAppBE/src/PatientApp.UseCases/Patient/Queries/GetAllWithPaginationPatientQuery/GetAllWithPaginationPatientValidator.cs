using FluentValidation;

namespace PatientApp.UseCases.Patient.Queries.GetAllWithPaginationPatientQuery
{
    public class GetAllWithPaginationPatientValidator : AbstractValidator<GetAllWithPaginationPatientQuery>
    {
        public GetAllWithPaginationPatientValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .NotNull()
                .NotEmpty();
        }
    }
}
