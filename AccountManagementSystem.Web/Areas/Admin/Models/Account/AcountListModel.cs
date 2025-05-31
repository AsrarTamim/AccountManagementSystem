using AccountManagementSystem.Domain;

namespace AccountManagementSystem.Web.Areas.Admin.Models.Account
{
    public class AccountListModel : DataTables
    {
        public AccountSearchModel SearchItem { get; set; }
    }

}
