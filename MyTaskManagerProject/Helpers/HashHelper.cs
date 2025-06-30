using System.Security.Cryptography;
using System.Text;

namespace MyTaskManagerProject.Helpers
{
    public class HashHelper
    {
        public static string ToSha256(string key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(key);

                byte[] hashBytes = sha256.ComputeHash(sourceBytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
