using Application.Dtos;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services
{
    public class RouteService(IUnitOfWorkRepository routeRepository, IMapper mapper)
    {
       
        public async Task<IEnumerable<RouteDto>> GetAllRoutesAsync()
        {
            var routes = await routeRepository.RouterRepository.GetAllAsync();
            return mapper.Map<IEnumerable<RouteDto>>(routes);
        }

        public async Task<RouteDto> GetRouteByIdAsync(int id)
        {
            var route = await routeRepository.RouterRepository.GetByIdAsync(id);
            return mapper.Map<RouteDto>(route);
        }

        public async Task<RouteDto> AddRouteAsync(RouteDto createRouteDto)
        {
            var route = mapper.Map<Route>(createRouteDto);
            await routeRepository.RouterRepository.AddAsync(route);
            return mapper.Map<RouteDto>(route);
        }

        public async Task UpdateRouteAsync(RouteDto updateRouteDto)
        {
            var route = mapper.Map<Route>(updateRouteDto);
            await routeRepository.RouterRepository.UpdateAsync(route);
        }

        public async Task DeleteRouteAsync(int id)
        {
            await routeRepository.RouterRepository.DeleteAsync(id);
        }

        public async Task<Route> GetRoutesByOriginAndDestinationAsync(string origin, string destination)
        {
            var allRoutes = await routeRepository.RouterRepository.GetRoutesByOriginAndDestinationAsync(origin, destination);

            if (allRoutes.Id==0)
            {
                return null;
            }
            return allRoutes;     
        }
    }
}
