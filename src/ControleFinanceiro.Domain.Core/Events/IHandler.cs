using MediatR;

namespace ControleFinanceiro.Domain.Core.Events
{
    public interface IHandler<in T> where T : INotification
    {
        void Handle(T message);
    }
}
