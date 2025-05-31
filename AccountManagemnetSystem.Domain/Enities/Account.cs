using AccountManagemnetSystem.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Domain.Entities
{
    public class Account : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string AccountType { get; set; }
        public double Cash { get; set; }
    }
}

