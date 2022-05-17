using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserMembership.Repository
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
