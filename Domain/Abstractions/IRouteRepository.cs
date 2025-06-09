using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IRouterRepository
    {
        Task<IEnumerable<Route>> GetAllAsync();
        Task<Route> GetByIdAsync(int id);
        Task AddAsync(Route route);
        Task UpdateAsync(Route route);
        Task DeleteAsync(int id);
        Task<Route?> GetRoutesByOriginAndDestinationAsync(string origin, string destination);
    }
}
