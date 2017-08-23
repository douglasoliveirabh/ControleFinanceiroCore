using ControleFinanceiro.Domain.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.Core.Events;
using System.Threading.Tasks;
using MediatR;

namespace ControleFinanceiro.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return Publish(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            //If will necessary save events. It's should do here 

            return Publish(@event);
        }
       
        private Task Publish<T>(T message) where T : INotification
        {
            return _mediator.Publish(message);
        }

    }
}
