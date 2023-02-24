using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorTest.Domain.Data
{
    internal class DatabaseContextFactory : IDesignTimeDbContextFactory<TestDBContext>
    {
        public TestDBContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<TestDBContext>();
            opsBuilder.UseSqlServer(appConfig.SqlConnectionString);
            return new TestDBContext(opsBuilder.Options);
        }
    }
}
