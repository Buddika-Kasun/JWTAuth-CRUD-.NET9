﻿namespace JWTAuthCRUD.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
