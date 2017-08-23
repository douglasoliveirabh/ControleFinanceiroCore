using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Commands
{
    public class AddressCommand : Command
    {
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string NeighborHood { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public int Number { get; set; }

        public AddressCommand(string postalCode, string city, string state, string country, string neighborHood, string street, string complement, int number)
        {
            PostalCode = postalCode;
            City = city;
            State = state;
            Country = country;
            NeighborHood = neighborHood;
            Street = street;
            Complement = complement;
            Number = number;
        }


        public override bool IsValid()
        {
            ValidationResult = new AddressValidation().Validate(this);            
            return ValidationResult.IsValid;
        }
    }
}
