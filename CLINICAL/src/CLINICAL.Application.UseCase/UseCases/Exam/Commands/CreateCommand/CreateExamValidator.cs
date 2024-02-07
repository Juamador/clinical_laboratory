using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamValidator: AbstractValidator<CreateExamCommand>
    {
        public CreateExamValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("The field Name can not be null")
                .NotEmpty().WithMessage("The field name can not be empty");
        }
    }
}
