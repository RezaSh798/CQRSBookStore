using CQRSBookStore.Commands;
using FluentValidation;

namespace CQRSBookStore.Validators;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("The book title cannot be longer than 100 characters.");
            
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author name is required.")
            .MaximumLength(50).WithMessage("Author name cannot be longer than 50 characters.");
    }
}