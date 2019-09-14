using AddressBook.Api.Models;
using AddressBook.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Api.DataContext
{
    public class SqlExpressContext : DbContext, ISqlExpressContext
    {
        public SqlExpressContext(DbContextOptions<SqlExpressContext> options) : base(options) { }
        
        public IRepository<User> Users => throw new NotImplementedException();

        public IRepository<AddressInfo> AddressInfo => throw new NotImplementedException();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
