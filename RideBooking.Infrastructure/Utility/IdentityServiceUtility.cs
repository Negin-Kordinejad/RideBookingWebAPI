using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RideBooking.Infrastructure.Utility
{
    public class IdentityServiceUtility : IIdentityServiceUtility
    {

        public string EncryptData(string data, string key, string iVector)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(string));
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, data);
            byte[] unencryptedBytes = memoryStream.ToArray();
            memoryStream.Close();

            byte[] encryptedBytes = Encrypt(unencryptedBytes,key, iVector);

            return Convert.ToBase64String(encryptedBytes);
        }

        public string DeserializeData(string encodedData, string key, string iVector)
        {
            var encryptedData = Convert.FromBase64String(encodedData);
            var data = Decrypt(encryptedData, key, iVector);

            using (var memoryStream = new MemoryStream(data))
            {
                var dataContractSerializer = new DataContractSerializer(typeof(string));
                return (string)dataContractSerializer.ReadObject(memoryStream);
            }
        }

        private byte[] Encrypt(byte[] unencryptedBytes, string key, string iVector)
        {
            var cryptoAlgorithm = Aes.Create();
            var sizes= cryptoAlgorithm.LegalKeySizes;
            MemoryStream memoryStream = new MemoryStream();

            ICryptoTransform encryptor = cryptoAlgorithm.CreateEncryptor(Convert.FromBase64String(key),
                                                                         Convert.FromBase64String(iVector));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(unencryptedBytes, 0, unencryptedBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] encryptedBytes = memoryStream.ToArray();
            cryptoAlgorithm.Clear();
            cryptoStream.Close();
            memoryStream.Close();

            return encryptedBytes;
        }
        private byte[] Decrypt(byte[] encryptedData, string key, string iVector)
        {
            var cryptoAlgorithm = Aes.Create();
            var memoryStream = new MemoryStream(encryptedData);
            ICryptoTransform decryptor = cryptoAlgorithm.CreateDecryptor(Convert.FromBase64String(key),
                Convert.FromBase64String(iVector));

            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            byte[] decryptedBytes = new byte[encryptedData.Length];
            int decryptedDataLength = 0;
            while (decryptedDataLength < decryptedBytes.Length)
            {
                var readLength = cryptoStream.Read(decryptedBytes, decryptedDataLength, decryptedBytes.Length - decryptedDataLength);
                if (readLength == 0) break;

                decryptedDataLength += readLength;
            }

            cryptoAlgorithm.Clear();
            cryptoStream.Close();
            memoryStream.Close();

            byte[] trimmedBytes = new byte[decryptedDataLength];
            Array.Copy(decryptedBytes, trimmedBytes, decryptedDataLength);

            return trimmedBytes;
        }
    }
}
