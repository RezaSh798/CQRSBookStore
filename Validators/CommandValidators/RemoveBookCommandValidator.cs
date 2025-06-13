using CQRSBookStore.Commands;
using FluentValidation;

namespace CQRSBookStore.Validators.CommandValidators;

public class RemoveBookCommandValidator : AbstractValidator<RemoveBookCommand>
{
    public RemoveBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}