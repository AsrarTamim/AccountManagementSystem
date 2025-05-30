namespace AccountManagementSystem.Web.Areas.Admin.Models.Account
{
    public class AccountSearchModel
    {
        public string Name { get; set; } = string.Empty;
        public string? AccountType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
