using ControleFinanceiro.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        protected readonly ILogger _logger;

        public BaseController(INotificationHandler<DomainNotification> notifications, ILogger logger)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _logger = logger;
        }

        public bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

    }
}
