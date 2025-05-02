using System.Collections.Generic;
using System.Threading.Tasks;
using AI.M.P.Core.Entities;   // <- Esta línea importa Account

namespace AI.M.P.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int id);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
    }
}
