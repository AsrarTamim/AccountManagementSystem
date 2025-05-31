using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagemnetSystem.Domain.Dtos
{
    public class AccountSearchDto
    {
        public string Name { get; set; } 
        public string AccountType { get; set; }
        public double? CashFrom { get; set; }
        public double? CashTo { get; set; }
    }
}
