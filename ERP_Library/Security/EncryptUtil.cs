using System;
using System.Text;
using System.Security.Cryptography;

namespace ERP_Library
{
    public static class EncryptUtil
    {
        public static string EncryptString(string message, string passphrase)
        {
            try
            {
                byte[] results;

                System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5

                // We use the MD5 hash generator as the result is a 128 bit byte array

                // which is a valid length for the TripleDES encoder we use below
                using (MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider())
                {
                    byte[] tDESKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));
                    // Step 2. Create a new TripleDESCryptoServiceProvider object
                    using (TripleDESCryptoServiceProvider tDESAlgorithm = new TripleDESCryptoServiceProvider())
                    {
                        // Step 3. Setup the encoder
                        tDESAlgorithm.Key = tDESKey;
                        tDESAlgorithm.Mode = CipherMode.ECB;
                        tDESAlgorithm.Padding = PaddingMode.PKCS7;
                        // Step 4. Convert the input string to a byte[]
                        byte[] dataToEncrypt = utf8.GetBytes(message);
                        // Step 5. Attempt to encrypt the string
                        try
                        {
                            ICryptoTransform encryptor = tDESAlgorithm.CreateEncryptor();
                            results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
                        }
                        finally
                        {
                            // Clear the TripleDes and Hashprovider services of any sensitive information
                            tDESAlgorithm.Clear();
                            hashProvider.Clear();
                        }
                    }
                }



                // Step 6. Return the encrypted string as a base64 encoded string

                return Convert.ToBase64String(results);
            }
            catch
            {

                return "";
            }

        }
        public static string DecryptString(string message, string passphrase)
        {
            try
            {
                byte[] results;

                UTF8Encoding utf8 = new UTF8Encoding();
                // Step 1. We hash the passphrase using MD5

                // We use the MD5 hash generator as the result is a 128 bit byte array

                // which is a valid length for the TripleDES encoder we use below
                using (MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider())
                {
                    byte[] tDESKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));
                    // Step 2. Create a new TripleDESCryptoServiceProvider object
                    TripleDESCryptoServiceProvider tDESAlgorithm = new TripleDESCryptoServiceProvider() { /* Step 3. Setup the decoder*/Key = tDESKey, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
                    // Step 4. Convert the input string to a byte[]
                    byte[] dataToDecrypt = Convert.FromBase64String(message);
                    // Step 5. Attempt to decrypt the string
                    try
                    {
                        ICryptoTransform decryptor = tDESAlgorithm.CreateDecryptor();
                        results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
                    }
                    finally
                    {
                        // Clear the TripleDes and Hashprovider services of any sensitive information
                        tDESAlgorithm.Clear();
                        hashProvider.Clear();
                    }
                }

                // Step 6. Return the decrypted string in UTF8 format
                return utf8.GetString(results);
            }
            catch
            {
                return "";
            }
        }

        public static string SHA512Encryption(string message)
        {
            SHA512 d_EncryptionSHA512 = new SHA512Managed();
            byte[] ByteHasEncryption = d_EncryptionSHA512.ComputeHash(Encoding.Default.GetBytes(message));
            StringBuilder StrBuilderStringEncryption = new StringBuilder();
            for (int i = 0; i < ByteHasEncryption.Length; i++)
            {
                StrBuilderStringEncryption.Append(ByteHasEncryption[i].ToString("x2"));
            }
            return StrBuilderStringEncryption.ToString();
        }

        public static String ComputeHash(String message, String algo)
        {
            byte[] sourceBytes = Encoding.Default.GetBytes(message);
            byte[] hashBytes = null;
            Console.WriteLine(algo);
            switch (algo.Trim().ToUpper())
            {
                case "MD5":
                    hashBytes = MD5CryptoServiceProvider.Create().ComputeHash(sourceBytes);
                    break;
                case "SHA1":
                    hashBytes = SHA1Managed.Create().ComputeHash(sourceBytes);
                    break;
                case "SHA256":
                    hashBytes = SHA256Managed.Create().ComputeHash(sourceBytes);
                    break;
                case "SHA384":
                    hashBytes = SHA384Managed.Create().ComputeHash(sourceBytes);
                    break;
                case "SHA512":
                    hashBytes = SHA512Managed.Create().ComputeHash(sourceBytes);
                    break;
                default:
                    break;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; hashBytes != null && i < hashBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", hashBytes[i]);
            }
            return sb.ToString();
        }

    }
}
