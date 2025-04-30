using System.Threading.Tasks;

namespace AI.M.P.Infrastructure.Services
{
    public class SmsService
    {
        public Task<string> SendVerificationCodeAsync(string phoneNumber)
        {
            // Aquí irá la llamada HTTP al proveedor de SMS
            return Task.FromResult("123456");
        }
    }
}
