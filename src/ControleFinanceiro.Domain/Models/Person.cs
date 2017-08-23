using ControleFinanceiro.Domain.Core.Models;
using ControleFinanceiro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Models
{
    public class Person : Entity
    {
        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }
                
        public Address Address { get; private set; }

        public Person(){
            Address = new Address();
        }

        public Person(string name, Address address)
        {
            Name = name;
            Address = address;
            CreationDate = DateTime.Now;
        }
    }
}
