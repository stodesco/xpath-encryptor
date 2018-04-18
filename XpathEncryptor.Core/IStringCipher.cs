namespace XpathEncryptor.Core
{
    /// <summary>
    /// Encrypts or decrypts a string
    /// </summary>
    public interface IStringCipher
    {
        string Decrypt(string cipherText, string passPhrase);
        string Encrypt(string plainText, string passPhrase);
    }
}