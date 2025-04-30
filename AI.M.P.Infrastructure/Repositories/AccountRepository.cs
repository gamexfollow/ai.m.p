using System.Collections.Generic;
using System.Threading.Tasks;
using AI.M.P.Application.Interfaces;
using AI.M.P.Core.Entities;
using AI.M.P.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AI.M.P.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _db;

        public AccountRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Account>> GetAllAsync() =>
            await _db.Accounts.ToListAsync();

        public async Task<Account?> GetByIdAsync(int id) =>
            await _db.Accounts.FindAsync(id);

        public async Task AddAsync(Account account)
        {
            await _db.Accounts.AddAsync(account);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _db.Accounts.Update(account);
            await _db.SaveChangesAsync();
        }
    }
}
