using ecommerce.application.dto.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Validation.Authentaication
{
 public class CreateUserValid:AbstractValidator<CreateUser>
    {
        public CreateUserValid()
        {
            RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("الاسم مطلوب")
            .MinimumLength(3).WithMessage("الاسم لازم يكون 3 حروف على الأقل");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("الإيميل مطلوب")
                .EmailAddress().WithMessage("الإيميل غير صحيح");

            RuleFor(x => x.Passowerd)
                .NotEmpty().WithMessage("الباسورد مطلوب")
                .MinimumLength(6).WithMessage("الباسورد لازم يكون 6 حروف على الأقل");

            RuleFor(x => x.ConfirmPassowerd)
                .Equal(x => x.Passowerd).WithMessage("الباسورد غير متطابق");
        }
    }
}
