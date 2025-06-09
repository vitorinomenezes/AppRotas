using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Infrastructure.Repositories
{
    public class UsersRepository(DbContext context) : IUsersRepository
    {
        public async Task AddAsync(Users data)
        {
            context.Set<Users>().Add(data);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await context.Set<Users>().FindAsync(id);
            if (data != null)
            {
                context.Set<Users>().Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await context.Set<Users>().ToListAsync();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await context.Set<Users>().FindAsync(id);
        }

        public async Task UpdateAsync(Users route)
        {
            context.Set<Users>().Update(route);
            await context.SaveChangesAsync();
        }
    }
}
