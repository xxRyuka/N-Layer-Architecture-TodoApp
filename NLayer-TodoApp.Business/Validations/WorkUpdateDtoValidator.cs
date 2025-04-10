using FluentValidation;
using NLayer_TodoApp.Dtos.WorkDtos;

namespace NLayer_TodoApp.Business.Validations;

public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
{
    
    public WorkUpdateDtoValidator()
    {
        RuleFor(wu => wu.Id).NotEmpty().WithMessage("Id cannot be empty");
        
        RuleFor(wu => wu.Definition)
            .NotEmpty().WithMessage("Definition cannot be empty")
            .MaximumLength(200).WithMessage("Maximum length is 200");

        RuleFor(wu => wu.isCompleted)
            .NotEmpty()
            .WithMessage("IsCompleted cannot be empty");
    }
}