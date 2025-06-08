using AccountManagementSystem.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Infrustructure.Seeds
{
    public static class RoleSeed
    {
        public static ApplicationRole[] GetRoles()
        {
            return [
                new ApplicationRole
                {
                    Id = new Guid("6B40ED0F-4B9C-4999-861A-6F0B3FC1D400"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = new DateTime(2025, 4, 19, 1, 2, 1).ToString(),
                },
                new ApplicationRole
                {
                    Id = new Guid("AE59C5FD-E084-409F-AC8F-F7D5E782357E"),
                    Name = "Accountant",
                    NormalizedName = "ACCOUNTANT",
                    ConcurrencyStamp = new DateTime(2025, 4, 19, 1, 2, 3).ToString(),
                },
                new ApplicationRole
                {
                    Id = new Guid("A26EFDE9-74F9-420E-B17E-D3E817681662"),
                    Name = "Viewer",
                    NormalizedName = "Viewer",
                    ConcurrencyStamp = new DateTime(2025, 4, 19, 1, 2, 4).ToString(),
                }
            ];
        }
    }
}


