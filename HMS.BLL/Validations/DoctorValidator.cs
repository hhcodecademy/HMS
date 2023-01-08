using FluentValidation;
using HMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Validations
{
    public class DoctorValidator : AbstractValidator<DoctorDto>
    {
        public DoctorValidator()
        {
        

            RuleFor(d => d.Name).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz");
            RuleFor(d => d.Email).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                  .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz"); ;
            RuleFor(d => d.Username).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                  .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz"); ;
        }
    }
}
