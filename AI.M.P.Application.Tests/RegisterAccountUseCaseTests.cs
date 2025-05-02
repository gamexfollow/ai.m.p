using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using AI.M.P.Application.UseCases;
using AI.M.P.Application.DTOs;
using AI.M.P.Infrastructure.Data;
using AI.M.P.Infrastructure.Repositories;

namespace AI.M.P.Application.Tests
{
    public class RegisterAccountUseCaseTests
    {
        private AppDbContext CreateInMemoryContext()
        {
            var opts = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(opts);
        }

        [Fact]
        public async Task Execute_CreatesAccountInDatabase()
        {
            // Arrange
            using var context = CreateInMemoryContext();
            var repo = new AccountRepository(context);
            var useCase = new RegisterAccountUseCase(repo);

            var dto = new AccountDto
            {
                Email = "alice@example.com",
                DisplayName = "Alice"
            };

            // Act
            await useCase.ExecuteAsync(dto);

            // Assert: se creó la entidad y coincide
            var saved = await repo.GetByIdAsync(1);
            Assert.NotNull(saved);
            Assert.Equal(dto.Email, saved!.Email);
            Assert.Equal(dto.DisplayName, saved.DisplayName);
        }
    }
}
