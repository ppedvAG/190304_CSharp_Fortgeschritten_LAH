using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Verschlüsseln
{
    class Program
    {
        static void Main(string[] args)
        {
            // Erster Aufruf
            #region AES-Beispiel
            //InitAESBeispiel("dieser Text funktioniert nicht :)");

            //Console.WriteLine("Bitte geben Sie das Passwort zum Entschlüsseln ein:");
            //string passwort = Console.ReadLine();
            //SHA256 sha256 = SHA256.Create();

            //AesManaged aes = new AesManaged();
            //aes.Key = sha256.ComputeHash(Encoding.Default.GetBytes(passwort));
            //aes.IV = File.ReadAllBytes("iv.bin");

            //// byte[] verschlüsselt = Verschlüsseln(aes, "asdasd");
            //try
            //{
            //    string entschlüsselt = Entschlüsseln(aes, File.ReadAllBytes("encText.bin"));
            //    Console.WriteLine(entschlüsselt);
            //}
            //catch (CryptographicException)
            //{
            //    Console.WriteLine("Ihr Passwort war leider falsch");
            //} 
            #endregion
            var rsa = RSACryptoServiceProvider.Create();

            if(! File.Exists("publicRSA.xml"))
            {
                File.WriteAllText("publicRSA.xml",rsa.ToXmlString(false));
                File.WriteAllText("privateRSA.xml",rsa.ToXmlString(true));
            }

            if(! File.Exists("rsa_text.bin"))
            {
                rsa.FromXmlString(File.ReadAllText("publicRSA.xml")); // mit pubkey verschlüsseln
                byte[] klartext = Encoding.Default.GetBytes("Das ist mein zu verschlüsselnder Text");
                File.WriteAllBytes("rsa_verschlüsselt.bin", rsa.Encrypt(klartext, RSAEncryptionPadding.OaepSHA1));
            }

            byte[] verschlüsselt = File.ReadAllBytes("rsa_verschlüsselt.bin");
            rsa.FromXmlString(File.ReadAllText("privateRSA.xml")); // mit privkey entschlüsseln

            string entschlüsselt = Encoding.Default.GetString(rsa.Decrypt(verschlüsselt, RSAEncryptionPadding.OaepSHA1));
            Console.WriteLine(entschlüsselt);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        static void InitAESBeispiel(string textZumVerschlüsseln)
        {
            if (!File.Exists("iv.bin"))
            {
                Console.WriteLine("Bitte geben Sie das Passwort zum Verschlüsseln ein:");
                string passwort = Console.ReadLine();

                SHA256 sha256 = SHA256.Create();
                var aes = new AesManaged();
                aes.Key = sha256.ComputeHash(Encoding.Default.GetBytes(passwort));

                File.WriteAllBytes("iv.bin", aes.IV);
                File.WriteAllBytes("encText.bin", Verschlüsseln(aes, textZumVerschlüsseln));
            }
        }

        static byte[] Verschlüsseln(AesManaged aes, string text)
        {
            var encryptor = aes.CreateEncryptor();
            byte[] plainTextAlsByteArray = Encoding.Default.GetBytes(text);
            using (MemoryStream memStream = new MemoryStream())
            {
                using (CryptoStream cryptStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cryptStream))
                    {
                        sw.Write(text);
                    }
                    return memStream.ToArray();
                }
            }
        }

        static string Entschlüsseln(AesManaged aes, byte[] verschlüsselt)
        {
            var decryptor = aes.CreateDecryptor();
            using (MemoryStream memStream = new MemoryStream(verschlüsselt))
            {
                using (CryptoStream cryptStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cryptStream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
