using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Data.Contracts
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;        
        int SaveChanges();
        void Dispose();
    }
}
