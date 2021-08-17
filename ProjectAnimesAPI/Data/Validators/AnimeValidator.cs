using FluentValidation;
using ProjectAnimesAPI.Models;

namespace ProjectAnimesAPI.Data.Validators
{
    public class AnimeValidator : AbstractValidator<Anime>
    {
        public AnimeValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Name field is required.")
                .NotEmpty().WithMessage("Name field is required.")
                .MaximumLength(200).WithMessage("Max length of Name field is 200 characters.");
        }
    }
}