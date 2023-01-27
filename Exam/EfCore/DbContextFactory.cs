using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.EfCore
{
    internal class DbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _optionsBuilder;

        public DbContextFactory(Action<DbContextOptionsBuilder> optionsBuilder) 
        {
            _optionsBuilder = optionsBuilder;
        }

        public DbContext CreateDbContext()
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            _optionsBuilder(builder);
            return new DatabaseContext(builder.Options);
        }
    }
}
