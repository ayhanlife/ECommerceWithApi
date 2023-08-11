using Entities.Dtos.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Validations.FluentValidation
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş gecilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş gecilemez");

        }
    }
}
