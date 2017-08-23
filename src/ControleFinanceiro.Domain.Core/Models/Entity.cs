using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Models
{
    public abstract class Entity
    {
        public long Id { get; protected set; }
    }
}
