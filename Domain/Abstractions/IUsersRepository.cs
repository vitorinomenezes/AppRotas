using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IUsersRepository
{
    Task<IEnumerable<Users>> GetAllAsync();
    Task<Users> GetByIdAsync(int id);
    Task AddAsync(Users route);
    Task UpdateAsync(Users route);
    Task DeleteAsync(int id);
}
