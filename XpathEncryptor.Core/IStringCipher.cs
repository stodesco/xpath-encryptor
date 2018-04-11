namespace XpathEncryptor.Core
{
    public interface IStringCipher
    {
        string Decrypt(string cipherText, string passPhrase);
        string Encrypt(string plainText, string passPhrase);
    }
}