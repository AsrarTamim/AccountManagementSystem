using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Application.Features.Accounts.Command
{
    public class AccountAddCommand:IRequest
    {
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string AccountType { get; set; }
        [Required]
        public double Cash { get; set; }

    }
}
