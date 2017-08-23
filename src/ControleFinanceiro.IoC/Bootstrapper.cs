using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MediatR;
using ControleFinanceiro.AppService;
using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Data.Contracts;
using ControleFinanceiro.Data.Repository;
using ControleFinanceiro.Data.UoW;
using ControleFinanceiro.Domain.CommandHandlers;
using ControleFinanceiro.Domain.Commands;
using ControleFinanceiro.Domain.Contracts;
using ControleFinanceiro.Domain.Contracts.AppService;
using ControleFinanceiro.Domain.Contracts.Repository;
using ControleFinanceiro.Domain.Core.Mediator;
using ControleFinanceiro.Domain.Core.Notifications;
using ControleFinanceiro.Domain.EventHandlers;
using ControleFinanceiro.Domain.Events;
using ControleFinanceiro.Mediator;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {           
            //Configure dependences here!            

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Application Service
            services.AddScoped<IPersonAppService, PersonAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<AddPersonEvent>, PersonEventHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<AddPersonCommand>, PersonCommandHandler>();

            //Infra - Data

            var optionsBuilder = new DbContextOptionsBuilder<ControleFinanceiroContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            services.AddScoped<IDbContext, ControleFinanceiroContext>(sp => new ControleFinanceiroContext(optionsBuilder.Options));
            services.AddScoped<IUnitOfWork, UnitOfWork>(sp => new UnitOfWork(sp.GetRequiredService<IDbContext>()));
            services.AddScoped<IPersonRepository, PersonRepository>();

        }

    }
}
