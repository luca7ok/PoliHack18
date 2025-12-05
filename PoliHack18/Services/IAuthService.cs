using PoliHack18.Models;

namespace PoliHack18.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(User user);
        Task LogoutAsync();
    }
}