using ControleFinanceiro.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.EventHandlers
{
    public class PersonEventHandler : INotificationHandler<AddPersonEvent>
    {
        public void Handle(AddPersonEvent notification)
        {
            // Send some notification after save person here!
        }
    }
}
