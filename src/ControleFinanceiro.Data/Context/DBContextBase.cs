using ControleFinanceiro.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Data.Context
{
    public class DBContextBase : DbContext, IDbContext
    {
        public DBContextBase(DbContextOptions options) : base(options)
        {

        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

    }
}
