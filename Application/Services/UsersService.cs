using Application.Dtos;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsersService(IUnitOfWorkRepository repository, IMapper mapper)
    {

        public async Task<IEnumerable<UsersDto>> GetAllAsync()
        {
            var routes = await repository.UsersRepository.GetAllAsync();
            return mapper.Map<IEnumerable<UsersDto>>(routes);
        }

        public async Task<UsersDto> GetByIdAsync(int id)
        {
            var route = await repository.UsersRepository.GetByIdAsync(id);
            return mapper.Map<UsersDto>(route);
        }

        public async Task<UsersDto> AddAsync(UsersDto createRouteDto)
        {
            var route = mapper.Map<Users>(createRouteDto);
            await repository.UsersRepository.AddAsync(route);
            return mapper.Map<UsersDto>(route);
        }

        public async Task UpdateAsync(UsersDto updateRouteDto)
        {
            var route = mapper.Map<Users>(updateRouteDto);
            await repository.UsersRepository.UpdateAsync(route);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.UsersRepository.DeleteAsync(id);
        }        
    }
}
