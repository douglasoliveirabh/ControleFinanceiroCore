using ControleFinanceiro.Data.Contracts;

namespace ControleFinanceiro.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        private string _contextKey = "ContextManager.Context";

        public ContextManager()
        {
            _contextKey = "ContextKey." + typeof(TContext).Name;
        }

        public void Finish()
        {
           /* if (HttpContext.Current.Items[_contextKey] != null)
                (HttpContext.Current.Items[_contextKey] as IDbContext).Dispose(); */
        }

        public TContext GetContext()
        {
            /* if (HttpContext.Current.Items[_contextKey] == null)
                HttpContext.Current.Items[_contextKey] = new TContext();
            return (TContext)HttpContext.Current.Items[_contextKey]; */

            return new TContext();
        }

    }
}
