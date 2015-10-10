using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using DoubleTakeInventory.Properties;
using System.Configuration;

namespace DoubleTakeInventory
{
    public class Decode
    {
        private static string connectionString { get; set; }
        public string ConnectionString { 
            get 
            {
                return connectionString;
            } 
            set 
            {
                string encryptedValue = value;
                connectionString = Decrypt(ConfigurationManager.ConnectionStrings[encryptedValue].ConnectionString);
            }
        }

        internal static readonly string PasswordHash = "9@$$30$6";
        internal static readonly string SaltKey = "21381842";
        internal static readonly string VIKey = "5e6a1w8d6g48w3fk";

        
        private string Decrypt(string encryptedText)
        {
            try
            {
                byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
                byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

                var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
                var memoryStream = new MemoryStream(cipherTextBytes);
                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
            }
            catch (Exception)
            {
                Console.WriteLine("Decryption Failure");
                return string.Empty;
            }
        }
    }
}