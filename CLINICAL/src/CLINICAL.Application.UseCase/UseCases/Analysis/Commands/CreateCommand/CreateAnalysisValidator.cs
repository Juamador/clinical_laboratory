using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisValidator: AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidator()
        {
            RuleFor(x=> x.Name)
                .NotNull().WithMessage("The field Name can not be null")
                .NotEmpty().WithMessage("The field Name can not be empty");
        }
    }
}
