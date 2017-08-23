﻿using ControleFinanceiro.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {            
            Key = key;
            Value = value;
        }
    }
}
