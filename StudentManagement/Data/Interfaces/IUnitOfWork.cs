using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {        
        Task CommitAsync();
    }
}
