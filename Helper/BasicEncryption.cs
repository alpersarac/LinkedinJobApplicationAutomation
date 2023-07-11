using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class BasicEncryption
    {
        public static string EncryptConnectionString(string plainText)
        {
            int key = 3; // Number of positions to shift characters
            StringBuilder cipherText = new StringBuilder();

            foreach (char c in plainText)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    cipherText.Append(c);
                    continue;
                }

                char encryptedChar = (char)(c + key);

                if (!char.IsLetterOrDigit(encryptedChar))
                {
                    encryptedChar = (char)(encryptedChar - 10);
                }

                cipherText.Append(encryptedChar);
            }

            return cipherText.ToString();
        }

        public static string DecryptConnectionString(string encryptedText)
        {
            int key = 3; // Number of positions to shift characters
            StringBuilder plainText = new StringBuilder();

            foreach (char c in encryptedText)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    plainText.Append(c);
                    continue;
                }

                char decryptedChar = (char)(c - key);

                if (!char.IsLetterOrDigit(decryptedChar))
                {
                    decryptedChar = (char)(decryptedChar + 10);
                }

                plainText.Append(decryptedChar);
            }

            return plainText.ToString();
        }
    }
}
