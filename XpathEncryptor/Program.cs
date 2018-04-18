using System;
using System.IO;
using System.Xml;
using XpathEncryptor.Core;

namespace XpathEncryptor
{
    /// <summary>
    /// XpathEncryptor encrypts values in an XML file. The value is specified by an XPath expression.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// You can start the app from the commandline with arguments, e.g.:
        /// XpathEncryptor.exe "..\..\..\XpathEncryptor.Consumer\bin\Debug\XpathEncryptor.Consumer.exe.config" "configuration/appSettings/add[@key='TestSetting']/@value" "VeryHard2Guess!"
        /// </summary>
        /// <param name="args">The arguments:
        /// 1) xml file path (e.g. app.config or web.config)
        /// 2) xpath targeting the value you want to replace
        /// 3) pass phrase (encryption key)</param>
        static void Main(string[] args)
        {
            var stringCypher = new StringCipher();
            string xmlFilePath;
            string xpathExpression;
            string passPhrase;
            if (args.Length == 0)
            {
                Console.WriteLine("XpathEncryptor encrypts values in an XML file. The value is specified by an XPath expression." +
                                  "You can invoke XpathEncryptor with the following commandline arguments:\n" +
                                  "1) xml file path (e.g. app.config or web.config)\n" +
                                  "2) xpath targeting the value you want to replace\n" +
                                  "3) pass phrase (encryption key)\n" +
                                  "If no parameters are provided the app is started in interactive mode and XpathEncryptor will" +
                                  "ask for input.");
                Console.WriteLine("\nXml File Path: \n");
                xmlFilePath = Console.ReadLine();
                Console.WriteLine("\nXPath Expression: \n");
                xpathExpression = Console.ReadLine();
                Console.WriteLine("\nPass Phrase: \n");
                passPhrase = Console.ReadLine();
            }
            else
            {
                xmlFilePath = args[0];
                xpathExpression = args[1];
                passPhrase = args[2];
            }

            var doc = new XmlDocument();
            var stream = new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            doc.Load(stream);
            var nodes = doc.SelectNodes(xpathExpression);
            foreach (XmlNode node in nodes)
            {
                node.InnerText = stringCypher.Encrypt(node.InnerText, passPhrase);
            }
            doc.Save(xmlFilePath);
        }
    }
}
