using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace MusicFestivalManagement.Helpers
{
    public static class PasswordHasher
    {
        public static Tuple<string, string> HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return Tuple.Create(hashed, Convert.ToBase64String(salt));
        }

        public static bool VerifyPassword(string enteredPassword, string storedSalt, string storedHash)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);
            string computedHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: enteredPassword,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return storedHash == computedHash;
        }
    }
}
