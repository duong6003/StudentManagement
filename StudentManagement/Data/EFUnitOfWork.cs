using StudentManagement.DataAccess;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly StudentManageContext _context;

        public EFUnitOfWork(StudentManageContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
