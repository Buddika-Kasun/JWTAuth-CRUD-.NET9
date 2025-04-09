using JWTAuthCRUD.DTOs;
using JWTAuthCRUD.Models;

namespace JWTAuthCRUD.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<string?> LoginAsync(UserDTO request);
    }
}
