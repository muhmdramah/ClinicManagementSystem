
using ClinicManagementSystem.Core.Auth;

namespace ClinicManagementSystem.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterDto model);

        Task<AuthModel> GetTokenAsync(LoginDto model);
    }
}