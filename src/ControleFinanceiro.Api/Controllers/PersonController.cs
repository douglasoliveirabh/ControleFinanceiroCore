using ControleFinanceiro.Domain.Contracts.AppService;
using ControleFinanceiro.Domain.Core.Notifications;
using ControleFinanceiro.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {

        private readonly IPersonAppService _personAppService;
        private readonly DomainNotificationHandler _notifications;        

        public PersonController(IPersonAppService personAppService, INotificationHandler<DomainNotification> notifications, ILogger<PersonController> logger) : base(notifications, logger)
        {
            _personAppService = personAppService;
            _notifications = (DomainNotificationHandler)notifications;
        }


        [HttpGet]
        [AllowAnonymous]        
        public IActionResult Index()
        {
            return Ok(_personAppService.GetAll());
        }


        [HttpGet("{id:long}")]
        [AllowAnonymous]
        public IActionResult Details(long? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var person = _personAppService.GetById(id.Value);

                if (person == null)
                    return NotFound();

                return Ok(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error while processing your request!");
            }
            
        }


        [HttpPost]        
        public IActionResult Create(Person person)
        {
            try
            {
                if (person == null)
                    return BadRequest();

                _personAppService.Add(person);

                if (IsValidOperation())
                    return Created(string.Format("api/person/{0}", person.Id), person);

                var errors = string.Join(',', _notifications.GetNotifications().Select(n => n.Value).ToArray());

                return NotFound(errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error while processing your request!");
            }           
        }



    }
}
