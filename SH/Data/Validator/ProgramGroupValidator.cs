using FluentValidation;
using SH.Data.ModelVM.Users;

namespace SH.Data.Validator
{
    public class ProgramGroupValidator : AbstractValidator<ProgramGroupVm>
    {
        public ProgramGroupValidator()
        {
            RuleFor(x => x.GroupName)
                .NotEmpty().WithMessage("ورود نام گروه اجباری می باشد!!!!")
                .Length(1, 100);
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ProgramGroupVm>
                .CreateWithOptions((ProgramGroupVm)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
