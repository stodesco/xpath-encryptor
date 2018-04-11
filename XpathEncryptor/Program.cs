using System.IO;
using System.Xml;
using XpathEncryptor.Core;

namespace XpathEncryptor
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments:
        /// 1) xml file path (e.g. app.config or web.config)
        /// 2) xpath targeting the value you want to replace
        /// 3) pass phrase (encryption key)</param>
        static void Main(string[] args)
        {
            var stringCypher = new StringCipher();
            var xmlFilePath = args[0];
            var xpathExpression = args[1];
            var passPhrase = args[2];

            var doc = new XmlDocument();
            var stream = new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            doc.Load(stream);
            var nodes = doc.SelectNodes(xpathExpression);
            foreach (XmlNode node in nodes)
            {
                node.InnerText = stringCypher.Encrypt(node.InnerText, passPhrase);
            }
            doc.Save(xmlFilePath);

            //Console.WriteLine("Please enter a password to use:");
            //string password = Console.ReadLine();
            //Console.WriteLine("Please enter a encrypted string:");
            //string encrypted = Console.ReadLine();
            //Console.WriteLine("");
            //Console.WriteLine("Your decrypted string is:");
            //string dc = StringCipher.Decrypt(encrypted, password);
            //Console.WriteLine(dc);
            //Console.WriteLine("");

            ////Console.WriteLine("Please enter a password to use:");
            ////string password = Console.ReadLine();
            //Console.WriteLine("Please enter a string to encrypt:");
            //string plaintext = Console.ReadLine();
            //Console.WriteLine("");

            //Console.WriteLine("Your encrypted string is:");
            //string encryptedstring = StringCipher.Encrypt(plaintext, password);
            //Console.WriteLine(encryptedstring);
            //Console.WriteLine("");

            //Console.WriteLine("Your decrypted string is:");
            //string decryptedstring = StringCipher.Decrypt(encryptedstring, password);
            //Console.WriteLine(decryptedstring);
            //Console.WriteLine("");
            
        }
    }
}
