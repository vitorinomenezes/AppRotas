using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RouteRepository(DbContext context) : IRouterRepository
    {     
        public async Task<IEnumerable<Route>> GetAllAsync()
        {
            return await context.Set<Route>().ToListAsync();
        }

        public async Task<Route> GetByIdAsync(int id)
        {
            return await context.Set<Route>().FindAsync(id);
        }

        public async Task AddAsync(Route route)
        {
            context.Set<Route>().Add(route);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Route route)
        {
            context.Set<Route>().Update(route);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var route = await context.Set<Route>().FindAsync(id);
            if (route != null)
            {
                context.Set<Route>().Remove(route);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Route?> GetRoutesByOriginAndDestinationAsync(string origin, string destination)
        {
            var voosDiretos = await context.Set<Route>()
                .Where(r => r.Origin.Contains(origin) && r.Destination.Contains(destination))
                .ToListAsync();

            return voosDiretos.Count > 0 ? voosDiretos.MinBy(r => r.Value) : null;
        }
    }
}
