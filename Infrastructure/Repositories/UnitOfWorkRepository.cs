using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UnitOfWorkRepository(DbContext _context
                        , IRouterRepository _router
                        , IUsersRepository _users) : IUnitOfWorkRepository, IDisposable
    {
        private bool _disposed = false;

        public IRouterRepository RouterRepository
        {
            get
            {
                return _router ??= new RouteRepository(_context);
            }
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                return _users ??= new UsersRepository(_context);
            }
        }     
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Public implementation of Dispose pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    _context.Dispose();
                }

                // Free unmanaged resources (if any) here.
                _disposed = true;
            }
        }

        // Destructor (finalizer) to ensure resources are released.
        ~UnitOfWorkRepository()
        {
            Dispose(false);
        }
    }
}
