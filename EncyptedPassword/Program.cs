// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Security.Cryptography;

namespace EncrepteAlgorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Encrepte("Kozlovskiy643212"));
        }

        public static string Encrepte(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            byte[] hashedPassword;
            using(SHA512 sha512 = SHA512.Create())
            {
                hashedPassword = sha512.ComputeHash(data);
                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                // X2 in ToString() means that string must be formatting in HEXADECIMAL notation
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedPassword)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
