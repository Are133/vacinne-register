using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VacinneRegister.Core.DTOs;

namespace VacinnerRegister.Infraestructure.Validators
{
    public class UserValidator:AbstractValidator<UserDTo>
    {
        public UserValidator()
        {
            //RuleFor(u => u.Name).NotEmpty().NotNull().Length(5, 50);
        }
    }
}
