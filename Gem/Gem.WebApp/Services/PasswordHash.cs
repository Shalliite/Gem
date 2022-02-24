﻿using Gem.WebApp.Migrations;
using Gem.WebApp.Models;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Gem.WebApp.Services
{
    public static class PasswordHash
    {
        public static string Hash(string password)
        {
            string password1 = password;
            byte[] salt = new byte[0];

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password1,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            password = hashed;
            return password;
        }
    }
}
