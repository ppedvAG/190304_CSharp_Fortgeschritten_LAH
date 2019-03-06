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
            InitBeispiel("dieser Text funktioniert nicht :)");

            Console.WriteLine("Bitte geben Sie das Passwort zum Entschlüsseln ein:");
            string passwort = Console.ReadLine();
            SHA256 sha256 = SHA256.Create();

            AesManaged aes = new AesManaged();
            aes.Key = sha256.ComputeHash(Encoding.Default.GetBytes(passwort));
            aes.IV = File.ReadAllBytes("iv.bin");

            // byte[] verschlüsselt = Verschlüsseln(aes, "asdasd");
            try
            {
                string entschlüsselt = Entschlüsseln(aes, File.ReadAllBytes("encText.bin"));
                Console.WriteLine(entschlüsselt);
            }
            catch (CryptographicException)
            {
                Console.WriteLine("Ihr Passwort war leider falsch");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        static void InitBeispiel(string textZumVerschlüsseln)
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
