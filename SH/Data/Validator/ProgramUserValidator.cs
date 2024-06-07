using FluentValidation;
using SH.Data.ModelVM.Users;

namespace SH.Data.Validator
{
    public class ProgramUserValidator : AbstractValidator<ProgramUserVm>
    {
        public ProgramUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("ورود نام اجباری می باشد!!!!")
                .Length(1, 100);
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .EmailAddress().WithMessage("آدرس ایمیل را به درستی وارد کنید");
            RuleFor(x => x.DcUsername)
                .NotEmpty().WithMessage("ورود نام کاربری اجباری می باشد");

        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ProgramUserVm>.CreateWithOptions((ProgramUserVm)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
