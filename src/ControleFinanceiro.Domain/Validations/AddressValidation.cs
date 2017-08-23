using ControleFinanceiro.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ControleFinanceiro.Domain.Validations
{
    public class AddressValidation : AbstractValidator<AddressCommand>
    {

        public AddressValidation()
        {
            ValidatePostalCode();
            ValidateCity();
            ValidateState();
            ValidateCountry();
            ValidateNeighborHood();
            ValidateStreet();
            ValidateNumber();
        }


        public void ValidatePostalCode()
        {
            RuleFor(a => a.PostalCode)
                .NotEmpty()
                //.Must(PostalCodeIsValid)
                .WithMessage("Informe um CEP válido.");
        }

        public void ValidateCity()
        {
            RuleFor(a => a.City)
                .NotEmpty()
                .WithMessage("Informe a cidade.");
        }

        public void ValidateState()
        {
            RuleFor(a => a.State)
                .NotEmpty()                
                .WithMessage("Informe o estado.");
        }

        public void ValidateCountry()
        {
            RuleFor(a => a.Country)
                .NotEmpty()
                .WithMessage("Informe um país.");
        }

        public void ValidateNeighborHood()
        {
            RuleFor(a => a.NeighborHood)
                .NotEmpty()
                .WithMessage("Informe um bairro.");
        }

        public void ValidateStreet()
        {
            RuleFor(a => a.Street)
                .NotEmpty()
                .WithMessage("Informe o logradouro.");
        }

        public void ValidateNumber()
        {
            RuleFor(a => a.Street)
                .NotEmpty()
                .WithMessage("Informe o número.");
        }

        private static bool PostalCodeIsValid(string postalCode)
        {
            int cep;
            var regex = new Regex("[^0-9]");
            var postalCodeWithoutEspecialCharacter = regex.Replace(postalCode, "");

            return int.TryParse(postalCode, out cep);
        }


    }
}
