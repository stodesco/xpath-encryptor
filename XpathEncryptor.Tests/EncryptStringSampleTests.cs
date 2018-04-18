using XpathEncryptor.Core;
using Xunit;

namespace XpathEncryptor.Tests
{
    public class XpathEncryptorTest
    {
        private IStringCipher _stringCypher;

        public XpathEncryptorTest()
        {
            _stringCypher = new StringCipher();
        }

        [Fact]
        public void CanEncryptAndDecryptSampleStringCorrectly()
        {
            // Arrange
            var plainText = "This is my sample plain text message";
            var passPhrase = "supersecretpassword";

            // Act
            var cipherText = _stringCypher.Encrypt(plainText, passPhrase);
            var decryptedText = _stringCypher.Decrypt(cipherText, passPhrase);

            // Assert
            Assert.Equal(plainText, decryptedText);
        }

        [Fact]
        public void EncryptingTheSamePlainTextWithTheSamePasswordMultipleTimesProducesDifferentCipherText()
        {
            // Arrange
            var plainText = "This is my sample plain text message";
            var passPhrase = "supersecretpassword";

            // Act
            var cipherText1 = _stringCypher.Encrypt(plainText, passPhrase);
            var cipherText2 = _stringCypher.Encrypt(plainText, passPhrase);

            // Assert
            Assert.NotEqual(cipherText1, cipherText2);
        }

        [Fact]
        public void EncryptingTheSamePlainTextWithTheSamePasswordMultipleTimesProducesDifferentCipherTextButBothCanBeDecryptedCorrectly()
        {
            // Arrange
            var plainText = "This is my sample plain text message";
            var passPhrase = "supersecretpassword";

            // Act
            var cipherText1 = _stringCypher.Encrypt(plainText, passPhrase);
            var cipherText2 = _stringCypher.Encrypt(plainText, passPhrase);
            var decryptedText1 = _stringCypher.Decrypt(cipherText1, passPhrase);
            var decryptedText2 = _stringCypher.Decrypt(cipherText2, passPhrase);

            // Assert
            Assert.Equal(decryptedText1, plainText);
            Assert.Equal(decryptedText1, decryptedText2);

        }
    }
}
