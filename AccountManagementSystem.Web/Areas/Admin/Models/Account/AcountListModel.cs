using AccountManagementSystem.Domain;

namespace AccountManagementSystem.Web.Areas.Admin.Models.Account
{
    public class AcountListModel : DataTables
    {
        public AccountSearchModel SearchItem { get; set; }
    }
}
