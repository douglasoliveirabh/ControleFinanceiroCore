using ControleFinanceiro.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Events
{
    public class AddPersonEvent : Event
    {

        public long Id { get; private set; }
        public string Name { get; private set; }

        public AddPersonEvent(long id, string name)
        {
            Id = id;
            Name = name;
        }


    }
}
