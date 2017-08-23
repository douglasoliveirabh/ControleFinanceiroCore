using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Commands
{
    public abstract class PersonCommand : Command
    {
        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }
        public AddressCommand Adress { get; private set; }

        public PersonCommand(string name, DateTime creationDate, AddressCommand address)
        {
            Name = name;
            CreationDate = CreationDate;
            Adress = address;
        }


    }
}
