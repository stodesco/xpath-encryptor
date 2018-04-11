using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpathEncryptor.Core;

namespace XpathEncryptor.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var passPhrase = args[0];
            var encrypted = ConfigurationManager.AppSettings["TestSetting"];
            Console.WriteLine($"This is the encrypted testSetting: {encrypted}");
            var stringCypher = new StringCipher();
            var decrypted = stringCypher.Decrypt(encrypted, passPhrase);
            Console.WriteLine($"This is the decrypted testSetting: {decrypted}");
            Console.ReadKey();
        }
    }
}
