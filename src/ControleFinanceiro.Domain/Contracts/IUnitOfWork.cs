using ControleFinanceiro.Domain.Core.Commands;
using System;

namespace ControleFinanceiro.Domain.Contracts
{
    public interface IUnitOfWork: IDisposable
    {        
        CommandResponse Commit();
    }
}
