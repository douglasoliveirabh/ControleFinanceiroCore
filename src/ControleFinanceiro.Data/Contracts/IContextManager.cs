namespace ControleFinanceiro.Data.Contracts
{
    public interface IContextManager<TContext> where TContext : IDbContext, new()
    {
        TContext GetContext();
        void Finish();
    }
}
