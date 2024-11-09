﻿using Sensor_Logger.Models;
using System.Security.Cryptography;
using System.Text.Json;

namespace Sensor_Logger.Services
{
    public class LoginService
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;
        private const string usersFile = "users.json";

        private static string GetHashedPassword(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(KeySize);

            var hashBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

            return Convert.ToBase64String(hashBytes);
        }

        private static bool VerifyPassword(string password, string passwordHash)
        {
            byte[] hashBytes = Convert.FromBase64String(passwordHash);

            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            byte[] storedPasswordHash = new byte[KeySize];
            Array.Copy(hashBytes, SaltSize, storedPasswordHash, 0, KeySize);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] enteredPasswordHash = pbkdf2.GetBytes(KeySize);

            return CryptographicOperations.FixedTimeEquals(storedPasswordHash, enteredPasswordHash);
        }



        public async Task<User?> IsValidUser(User user)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(usersFile);
            using var reader = new StreamReader(stream);

            string jsonContent = await reader.ReadToEndAsync();

            var users = JsonSerializer.Deserialize<List<User>>(jsonContent);

            return users?.FirstOrDefault(u => u.Username.Equals(user.Username) && VerifyPassword(user.Password, u.Password));
        }
    }
}