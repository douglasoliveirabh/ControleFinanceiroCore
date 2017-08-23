using ControleFinanceiro.Domain.Commands;
using ControleFinanceiro.Domain.Contracts;
using ControleFinanceiro.Domain.Contracts.Repository;
using ControleFinanceiro.Domain.Core.Mediator;
using ControleFinanceiro.Domain.Core.Notifications;
using ControleFinanceiro.Domain.Events;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.CommandHandlers
{
    public  class PersonCommandHandler : CommandHandler, INotificationHandler<AddPersonCommand>
    {

        private readonly IPersonRepository _personRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public PersonCommandHandler(IPersonRepository personRepository, 
                                    IUnitOfWork uow ,
                                    IMediatorHandler mediatorHandler, 
                                    INotificationHandler<DomainNotification> notifications) : base(uow, mediatorHandler, notifications)
        {
            _personRepository = personRepository;            

        }

        public void Handle(AddPersonCommand command)
        {

            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return;
            }

            var address = new Address(command.Adress.PostalCode, command.Adress.City, command.Adress.State, 
                                      command.Adress.Country, command.Adress.NeighborHood, command.Adress.Street, 
                                      command.Adress.Complement, command.Adress.Number);

            var person = new Person(command.Name, address);

            // if exists bussiness validation, you should validate here!


            _personRepository.Add(person);


            if (Commit())
            {
                _mediatorHandler.RaiseEvent(new AddPersonEvent(person.Id, person.Name));
            }

        }
    }
}
