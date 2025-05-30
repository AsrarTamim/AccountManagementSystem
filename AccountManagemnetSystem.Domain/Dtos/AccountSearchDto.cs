using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagemnetSystem.Domain.Dtos
{
    public class AccountSearchDto
    {
        public string Name { get; set; } = string.Empty;
        public string? AccountType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
