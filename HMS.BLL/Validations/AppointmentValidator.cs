using FluentValidation;
using HMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Validations
{
    public class AppointmentValidator: AbstractValidator<AppointmentDto>
    {
        public AppointmentValidator()
        {

            RuleFor(d => d.Number).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz");
            RuleFor(d => d.Type).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                  .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz"); ;
            RuleFor(d => d.Description).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                  .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz");

            RuleFor(x => x.DoctorId).GreaterThan(0).WithMessage("Xahiş edirem  {PropertyName} alanına düzgün dəyər daxil ediniz");
        }
    }
}
