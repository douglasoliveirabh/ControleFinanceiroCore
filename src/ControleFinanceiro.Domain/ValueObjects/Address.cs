using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.ValueObjects
{
    public class Address
    {
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string NeighborHood { get; private set; }
        public string Street { get; private set; }
        public string Complement { get; private set; }
        public int Number { get; private set; }

        public Address(){}

        public Address(string postalCode, string city, string state, string country, string neighborHood, string street, string complement, int number)
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
    }
}
