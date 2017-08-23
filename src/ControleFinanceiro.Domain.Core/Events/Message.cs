using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Events
{
    public class Message : INotification
    {

        public string MessageType { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
