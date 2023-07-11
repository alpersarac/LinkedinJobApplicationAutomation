using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJAASerial.FileReader
{
    public class ConnectionStringEncryptor
    {
        private const int KeySize = 256;
        private const int Iterations = 1000;

        private readonly string password;

        public ConnectionStringEncryptor(string password)
        {
            this.password = password;
        }

        public void EncryptAndSaveConnectionString(string connectionString, string filePath)
        {
            byte[] salt = GenerateSalt();
            byte[] iv = GenerateIV();
            byte[] key = GenerateKey(salt);

            byte[] encryptedBytes = EncryptStringToBytes(connectionString, key, iv);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    writer.Write(salt);
                    writer.Write(iv);
                    writer.Write(encryptedBytes);
                }
            }

            Console.WriteLine("Encrypted connection string saved to: " + filePath);
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                randomGenerator.GetBytes(salt);
            }
            return salt;
        }

        private byte[] GenerateIV()
        {
            byte[] iv = new byte[16];
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                randomGenerator.GetBytes(iv);
            }
            return iv;
        }

        private byte[] GenerateKey(byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                return rfc2898DeriveBytes.GetBytes(KeySize / 8);
            }
        }

        private byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            byte[] encryptedBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                        }
                        encryptedBytes = memoryStream.ToArray();
                    }
                }
            }
            return encryptedBytes;
        }
    }

}
