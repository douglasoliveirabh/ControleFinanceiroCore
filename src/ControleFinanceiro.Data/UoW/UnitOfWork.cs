using ControleFinanceiro.Data.Contracts;
using ControleFinanceiro.Domain.Contracts;
using ControleFinanceiro.Domain.Core.Commands;

namespace ControleFinanceiro.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
