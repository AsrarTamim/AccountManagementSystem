using AccountManagemnetSystem.Domain;
using AccountManagemnetSystem.Infrastructure;
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
        protected ISqlUtility SqlUtility { get; private set; }

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
            SqlUtility = new SqlUtility(_dbContext.Database.GetDbConnection());

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
