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

/*using FluentValidation;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Please enter an email address.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Please enter a password.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(user => user.ConfirmPassword)
                .Equal(user => user.Password).WithMessage("Password and confirmation password do not match.");

            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("Please enter a username.");

            RuleFor(user => user.IsActive)
                .NotEmpty().WithMessage("Please specify the user's activation status.");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("Please enter a phone number.")
                .Matches(@"^(77|78|73|71)\d{7}$") // يبدأ بـ 77 أو 78 أو 73 أو 71 ويتبعه 7 أرقام أخرى
                .WithMessage("Please enter a valid phone number starting with 77, 78, 73, or 71 and containing a total of 9 digits.");
        }
    }
}*/
