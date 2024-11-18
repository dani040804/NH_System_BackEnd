using Microsoft.EntityFrameworkCore.Storage;
using NH_Sys_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH_Sys_Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbDevContext _context;
        private IDbContextTransaction? _currentTransaction;

        public UnitOfWork(DbDevContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _currentTransaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.CommitAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

}
