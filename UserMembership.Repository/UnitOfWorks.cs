using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserMembership.Data;

namespace UserMembership.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserMembershipDbContext _context;

        public UnitOfWork(UserMembershipDbContext tMDbContext)
        {
            _context = tMDbContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
