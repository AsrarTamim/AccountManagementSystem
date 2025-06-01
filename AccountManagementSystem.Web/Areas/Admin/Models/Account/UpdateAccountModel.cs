using System.ComponentModel.DataAnnotations;

namespace AccountManagementSystem.Web.Areas.Admin.Models.Account
{
    public class UpdateAccountModel
    {
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string AccountType { get; set; }
        [Required]
        public double Cash { get; set; }
    }
}
