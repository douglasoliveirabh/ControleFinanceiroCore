using ControleFinanceiro.Domain.Contracts.AppService;
using System;
using System.Collections.Generic;
using System.Text;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.Contracts.Repository;
using ControleFinanceiro.Domain.Core.Mediator;
using ControleFinanceiro.Domain.Commands;

namespace ControleFinanceiro.AppService
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IPersonRepository _personRepository;

        public PersonAppService(IPersonRepository personRepository, 
                                IMediatorHandler mediator)
        {
            _mediator = mediator;
            _personRepository = personRepository;
        }


        public void Add(Person entity)
        {
            //I can use automapper here !
            var addressCommand = new AddressCommand(entity.Address.PostalCode, entity.Address.City, entity.Address.State, 
                                                    entity.Address.Country, entity.Address.NeighborHood, entity.Address.Street, 
                                                    entity.Address.Complement, entity.Address.Number);

           var addPersonCommand = new AddPersonCommand(entity.Name, addressCommand); 
        

            _mediator.SendCommand(addPersonCommand);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person GetById(long id)
        {
            return _personRepository.GetById(id);
        }

        public void Remove(Person entity)
        {
            //_personRepository.Remove(entity.id);
        }

        public void Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
