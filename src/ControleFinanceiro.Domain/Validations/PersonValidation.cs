using ControleFinanceiro.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Validations
{
    public class PersonValidation<T> : AbstractValidator<T> where T : PersonCommand
    {
        public void ValidateName() {

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Favor informar o nome.")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");

        }



    }
}
