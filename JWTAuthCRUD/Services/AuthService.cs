using JWTAuthCRUD.Data;
using JWTAuthCRUD.DTOs;
using JWTAuthCRUD.Helpers;
using JWTAuthCRUD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthCRUD.Services
{
    public class AuthService(AppDbContext context, JwtHelper jwtHelper) : IAuthService
    {
        public async Task<User?> RegisterAsync(UserDTO request)
        {

            if (await context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return null;
            }

            var user = new User();

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.Username = request.Username;
            user.PasswordHash = hashedPassword;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<string?> LoginAsync(UserDTO request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user is null)
            {
                //return BadRequest("User not found");
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                //return BadRequest("Wrong password");
                return null;
            }

            //string token = GenerateToken(user);

            //return Ok(token);

            return jwtHelper.GenerateToken(user);
        }

    }
}
