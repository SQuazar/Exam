using Exam.Domain.Model;
using Exam.Domain.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.EfCore.Service
{
    internal class PharmacyService : IPharmacyService
    {
        private readonly DbContextFactory _factory;

        public PharmacyService(DbContextFactory factory)
        {
            _factory = factory;
        }

        public async Task<Pharmacy> Create(Pharmacy entity)
        {
            await using var ctx = _factory.CreateDbContext();
            var e = await ctx.Set<Pharmacy>().AddAsync(entity);
            await ctx.SaveChangesAsync();
            return e.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            await using var ctx = _factory.CreateDbContext();
            var entity = await ctx.Set<Pharmacy>().Where(p => p.Id == id).FirstOrDefaultAsync();
            if (entity == null) return false;
            ctx.Set<Pharmacy>().Remove(entity);
            await ctx.SaveChangesAsync();
            return true;
        }

        public async Task<List<Pharmacy>> GetAll()
        {
            await using var ctx = _factory.CreateDbContext();
            return await ctx.Set<Pharmacy>().ToListAsync();
        }

        public async Task<Pharmacy> GetById(int id)
        {
            await using var ctx = _factory.CreateDbContext();
            var entity = await ctx.Set<Pharmacy>().Where(p => p.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<Pharmacy> Update(int id, Pharmacy entity)
        {
            await using var ctx = _factory.CreateDbContext();
            entity.Id = id;
            ctx.Entry(entity).State = EntityState.Modified;
            await ctx.SaveChangesAsync();
            return entity;
        }
    }
}
