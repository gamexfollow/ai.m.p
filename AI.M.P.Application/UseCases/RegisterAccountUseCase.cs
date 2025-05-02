using System;
using System.Threading.Tasks;
using AI.M.P.Application.Interfaces;
using AI.M.P.Application.DTOs;
using AI.M.P.Core.Entities;

namespace AI.M.P.Application.UseCases
{
    public class RegisterAccountUseCase
    {
        private readonly IAccountRepository _repository;

        public RegisterAccountUseCase(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountDto> ExecuteAsync(AccountDto dto)
        {
            // Mapeamos el DTO a la entidad
            var account = new Account
            {
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                CreatedAt = dto.CreatedAt == default
                    ? DateTime.UtcNow
                    : dto.CreatedAt
            };

            // Guardamos en el repositorio
            await _repository.AddAsync(account);

            // Devolvemos un nuevo DTO con el Id asignado
            return new AccountDto
            {
                Id = account.Id,
                Email = account.Email,
                DisplayName = account.DisplayName,
                CreatedAt = account.CreatedAt
            };
        }
    }
}
