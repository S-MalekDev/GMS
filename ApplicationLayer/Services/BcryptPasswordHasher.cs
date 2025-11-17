using CoreLayer.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public string Hash(string password) =>  BCrypt.Net.BCrypt.HashPassword(password.Trim().ToLower());
        public bool Verify(string password, string hashedPassword) => BCrypt.Net.BCrypt.Verify(password.Trim().ToLower(), hashedPassword);
    }
}
