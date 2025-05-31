namespace AccountManagementSystem.Web.Areas.Admin.Models.Account
{
    public class AccountSearchModel
    {
        public string Name { get; set; }
        public string AccountType { get; set; }
        public int? CashFrom { get; set; }
        public int? CashTo { get; set; }
    }
}
