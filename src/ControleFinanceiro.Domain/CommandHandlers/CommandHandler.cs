using ControleFinanceiro.Domain.Contracts;
using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.Core.Mediator;
using ControleFinanceiro.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _notifications;


        public CommandHandler(IUnitOfWork uow, IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> notifications)
        {
            _unitOfWork = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _unitOfWork.Commit();
            if (commandResponse.Success) return true;

            _mediatorHandler.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }

    }
}
