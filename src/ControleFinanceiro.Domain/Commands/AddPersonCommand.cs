using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ControleFinanceiro.Domain.ValueObjects;

namespace ControleFinanceiro.Domain.Commands
{
    public class AddPersonCommand : PersonCommand
    {

        public AddPersonCommand(string name, AddressCommand address) : base(name, DateTime.Now, address) { }
        

        public override bool IsValid()
        {
            ValidationResult = new AddPersonValidation().Validate(this);
            var addressValidationResult = new AddressValidation().Validate(this.Adress);

            ValidationResult.Errors.Concat(addressValidationResult.Errors);

            return ValidationResult.IsValid && addressValidationResult.IsValid;
        }


    }
}
