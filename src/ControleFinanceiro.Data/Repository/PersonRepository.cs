using ControleFinanceiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ControleFinanceiro.Data.Contracts;
using ControleFinanceiro.Domain.Contracts.Repository;

namespace ControleFinanceiro.Data.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext context) : base(context)
        {
        }
    }
}
