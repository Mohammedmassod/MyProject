using FluentValidation;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("يرجى إدخال عنوان بريد إلكتروني.")
                .EmailAddress().WithMessage("البريد الإلكتروني غير صحيح.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("يرجى إدخال كلمة مرور.")
                .MinimumLength(8).WithMessage("يجب أن تتألف كلمة المرور  الأقل من 8 أحرف.");

            RuleFor(user => user.ConfirmPassword)
                .Equal(user => user.Password).WithMessage("كلمة المرور وتأكيد كلمة المرور غير متطابقين.");

            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("يرجى إدخال اسم مستخدم.");

            RuleFor(user => user.IsActive)
                .NotEmpty().WithMessage("يرجى تحديد حالة تفعيل المستخدم.");

            RuleFor(user => user.PhoneNumber)
             .NotEmpty().WithMessage("يرجى إدخال رقم هاتف.")
             .Matches(@"^\+[1-9]\d{1,14}$") // Example regex pattern (modify as needed)
             .WithMessage("يرجى إدخال رقم هاتف صحيح.");

        }
    }
}
