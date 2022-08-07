using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using DataAccess.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TempContext _context;

        private readonly IUserRepository _userRepository;

        public UnitOfWork(TempContext context)
        {
            if (context == null)
                throw new ArgumentNullException("dbContext can not be null.");
            _context = context;
        }

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);


        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
