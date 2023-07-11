using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helper.FileReader
{
    public class ConnectionStringDecryptor
    {
        private const int KeySize = 256;
        private const int Iterations = 1000;

        private readonly string password;

        public ConnectionStringDecryptor(string password)
        {
            this.password = password;
        }

        public string DecryptConnectionStringFromFile(string filePath)
        {
            byte[] salt;
            byte[] iv;
            byte[] encryptedBytes;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    salt = reader.ReadBytes(16);
                    iv = reader.ReadBytes(16);
                    encryptedBytes = reader.ReadBytes((int)(fileStream.Length - fileStream.Position));
                }
            }

            byte[] key = GenerateKey(salt);

            string decryptedString = DecryptBytesToString(encryptedBytes, key, iv);

            return decryptedString;
        }

        public string DecryptConnectionStringFromString(string encryptedString)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedString);

            byte[] salt = new byte[16];
            byte[] iv = new byte[16];
            byte[] encryptedData = new byte[encryptedBytes.Length - 32];

            Array.Copy(encryptedBytes, salt, 16);
            Array.Copy(encryptedBytes, 16, iv, 0, 16);
            Array.Copy(encryptedBytes, 32, encryptedData, 0, encryptedData.Length);

            byte[] key = GenerateKey(salt);

            string decryptedString = DecryptBytesToString(encryptedData, key, iv);

            return decryptedString;
        }

        private byte[] GenerateKey(byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                return rfc2898DeriveBytes.GetBytes(KeySize / 8);
            }
        }

        private string DecryptBytesToString(byte[] encryptedBytes, byte[] key, byte[] iv)
        {
            string decryptedString;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            decryptedString = reader.ReadToEnd();
                        }
                    }
                }
            }
            return decryptedString;
        }
    }

}
