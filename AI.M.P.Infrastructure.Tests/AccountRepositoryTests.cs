using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using AI.M.P.Core.Entities;
using AI.M.P.Infrastructure.Data;
using AI.M.P.Infrastructure.Repositories;
using System.Security.Principal;

namespace AI.M.P.Infrastructure.Tests
{
    public class AccountRepositoryTests
    {
        private AppDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task AddAndRetrieveAccount_WorksCorrectly()
        {
            // Arrange: context y repositorio
            using var context = CreateInMemoryContext();
            var repo = new AccountRepository(context);
            var account = new Account
            {
                Email = "test@example.com",
                DisplayName = "Test User",
                CreatedAt = DateTime.UtcNow
            };

            // Act: guardar y luego recuperar
            await repo.AddAsync(account);
            var retrieved = await repo.GetByIdAsync(account.Id);

            // Assert: valores coinciden
            Assert.NotNull(retrieved);
            Assert.Equal(account.Email, retrieved!.Email);
            Assert.Equal(account.DisplayName, retrieved.DisplayName);
        }
    }
}
