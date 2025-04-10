using FluentValidation;
using NLayer_TodoApp.Dtos.WorkDtos;

namespace NLayer_TodoApp.Business.Validations;

public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
{
    public WorkCreateDtoValidator()
    {
        Func<string,bool> yika = x => x!="yika";
        
        RuleFor(wu => wu.Definition)
            .NotEmpty().WithMessage("Definition cannot be empty")
            .MaximumLength(200).WithMessage("Maximum length is 200")
            .Must(yika).WithMessage("Definition cannot be Bulasik");

        RuleFor(wu => wu.isCompleted)
            .NotEmpty()
            .WithMessage("IsCompleted cannot be empty");
    }

    private bool filter(string arg)
    {
        arg = arg.ToLower();
        if (arg.Contains("bulasik"))
        {
            return false;
        }
        return true;
    }
}