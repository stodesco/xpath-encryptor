using System;
using System.Configuration;
using XpathEncryptor.Core;

namespace XpathEncryptor.Consumer
{
    /// <summary>
    /// An example app that shows how to use XpathEncryptor to decrypt a previously encrypted app.config file.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a test app for the XpathEncryptor project. It allows you to decrypt an app setting value in it's " +
                              "App.config file previously encrypted. The app asks for value interactively. Default values " +
                              "(shown in angle brackets) are assumed when you press enter without providing any input.\n");
            var defaultPassPhrase = "VeryHard2Guess!";
            Console.WriteLine($"Enter Pass Phrase [{defaultPassPhrase}]");
            var passPhrase = Console.ReadLine();
            if (string.IsNullOrEmpty(passPhrase)) passPhrase = defaultPassPhrase;

            var defaultAppSettingKey = "TestSetting";
            Console.WriteLine($"Enter App Setting Key [{defaultAppSettingKey}]");
            var appSettingsKey = Console.ReadLine();
            if (string.IsNullOrEmpty(appSettingsKey)) appSettingsKey = defaultAppSettingKey;

            var encrypted = ConfigurationManager.AppSettings[appSettingsKey];
            if (encrypted == null)
            {
                Console.WriteLine($"No App Setting value found with key {appSettingsKey}. ");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"This is the encrypted app setting value: \n{encrypted}");
            var stringCypher = new StringCipher();
            try
            {
                var decrypted = stringCypher.Decrypt(encrypted, passPhrase);
                Console.WriteLine($"\nThis is the decrypted app setting value: \n{decrypted}");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while trying to decrypt the value. Check if the value has been encrypted previously. " +
                                  "If not, use XpathEncryptor to encrypt the value.");
                Console.WriteLine();
                Console.WriteLine("Exception Message:");
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
