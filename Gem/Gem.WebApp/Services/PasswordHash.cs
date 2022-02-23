using Gem.WebApp.Migrations;
using Gem.WebApp.Models;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Gem.WebApp.Services
{
    public static class PasswordHash
    {
        public static RegistrationModel Hash(RegistrationModel rm)
        {
            string password = rm.Password;
            byte[] salt = new byte[0];

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            rm.Password = hashed;
            return rm;
        }
    }
}
