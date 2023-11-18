using NajotTalim.Application.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace NajotTalim.Infrastructure.HashGenerators
{
    public class HashProvider : IHashProvider
    {
        public string GetHash(string password)
        {
            const int keySize = 64;
            const int itearations = 35000;

            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                            Encoding.UTF8.GetBytes(password),
                            new byte[0],
                            itearations,
                            hashAlgorithm,
                            keySize);

            return Convert.ToHexString(hash);
        }
    }
}
