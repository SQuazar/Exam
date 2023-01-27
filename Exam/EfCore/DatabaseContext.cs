using Exam.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Exam.EfCore
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies => Set<Pharmacy>();

        public DatabaseContext(DbContextOptions options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>().HasData(new[]
            {
                new Pharmacy { Id = 1, Name = "Госздрав", Address = "Улица Сишвская, дом 20", StartWorking = new TimeSpan(8, 0, 0), EndWorking = new TimeSpan(23, 0, 0) }
            });
        }
    }
}
