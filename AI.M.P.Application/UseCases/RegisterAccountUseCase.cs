using System.Threading.Tasks;
using AI.M.P.Application.Interfaces;
using AI.M.P.Application.DTOs;

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
            // Aquí irá la lógica para mapear el DTO a la entidad,
            // guardar en repositorio y devolver el resultado.
            // Por ahora, simplemente retornamos el mismo DTO:
            return dto;
        }
    }
}
