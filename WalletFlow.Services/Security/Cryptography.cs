using System.Security.Cryptography;
using System.Text;

namespace WalletFlow.Services.Security
{
    public static class Cryptography
    {
        public static string CryptographyPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hashBytes = sha256Hash.ComputeHash(bytes);

                StringBuilder hashString = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashString.Append(b.ToString("x2"));
                }

                return hashString.ToString();
            }

        }
    }
}
