using ecommerce.application.dto.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.Validation.Authentaication
{
   public class LoginyserValidete:AbstractValidator<LoginUser>
    {
        public LoginyserValidete()
        {
 

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("الإيميل مطلوب")
                .EmailAddress().WithMessage("الإيميل غير صحيح");

            RuleFor(x => x.Passowerd)
                .NotEmpty().WithMessage("الباسورد مطلوب")
                .MinimumLength(6).WithMessage("الباسورد لازم يكون 6 حروف على الأقل");

         
        }
    }
}
