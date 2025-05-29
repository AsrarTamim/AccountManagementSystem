using AccountManagemnetSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Infrustructure
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
    }
}
