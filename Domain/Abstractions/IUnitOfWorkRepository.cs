using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IUnitOfWorkRepository
    {
        IRouterRepository RouterRepository { get; }
        IUsersRepository UsersRepository { get; }
        Task CommitAsync();
    }
}
