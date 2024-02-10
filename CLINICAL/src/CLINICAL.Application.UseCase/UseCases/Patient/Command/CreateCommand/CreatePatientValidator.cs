using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Command.CreateCommand
{
    public class CreatePatientValidator: AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.Names)
                 .NotNull().WithMessage("The Names field can not be null")
                 .NotEmpty().WithMessage("The names field can not be empty");

            RuleFor(x => x.LastName)
                 .NotNull().WithMessage("The Last Name field can not be null")
                 .NotEmpty().WithMessage("The Last Name field can not be empty");

            RuleFor(x => x.MotherMaidenName)
                 .NotNull().WithMessage("The Mother's last name field can not be null")
                 .NotEmpty().WithMessage("The Mother's last name field can not be empty");


            RuleFor(x => x.DocumentNumber)
                 .NotNull().WithMessage("The Document Númber field can not be null")
                 .NotEmpty().WithMessage("The Document Númber field can not be empty")
                 .Must(BeNumeric!).WithMessage("The Document Number field should only contain numbers");

            RuleFor(x => x.Phone)
                 .NotNull().WithMessage("The Phone number field can not be null")
                 .NotEmpty().WithMessage("The Phone number field can not be empty")
                 .Must(BeNumeric!).WithMessage("The Phone number field should only contain numbers");
        }

        private bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}
