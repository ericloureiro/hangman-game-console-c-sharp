using System;
using System.Text;

namespace HangmanGame
{
    public class WordsModel
    {
        public string awnser;
        public StringBuilder awnserEncrypted;
        public string[] wordsPool;

        /// <summary>
        /// Generate and encrypt a new random word
        /// </summary>
        public void RefreshData()
        {
            awnser = GenerateRandomWord();
            awnserEncrypted = EncryptAwnser();
        }

        /// <summary>
        /// Called when the user scores a letter to show where on the encrypted awnser.
        /// Replace '_' by the <paramref name="input"/> at the position <paramref name="i"/> on the encrypted awnser
        /// </summary>
        /// <param name="input"></param>
        /// <param name="i"></param>
        public void ReplaceAwnserEncryptedChar(string input, int i)
        {
            awnserEncrypted.Remove(i, 1);
            awnserEncrypted.Insert(i, input);
        }

        /// <summary>
        /// Encrypt awnser by turning every character into a '_' to give a visual feedback to user
        /// </summary>
        /// <returns></returns>
        private StringBuilder EncryptAwnser()
        {
            StringBuilder awnserEncrypted = new StringBuilder();

            for (int i = 0; i < awnser.Length; i++)
            {
                awnserEncrypted.Append("_");
            }

            return awnserEncrypted;
        }

        /// <summary>
        /// Return generated random word from pool
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomWord()
        {
            Random random = new Random();

            return wordsPool[random.Next(0, wordsPool.Length)];
        }

        /// <summary>
        /// Fetch words from DBController
        /// </summary>
        /// <returns></returns>
        public bool GetWords()
        {
            try
            {         
                wordsPool = DBController.FetchJSON();
            }
            catch (Exception e)
            {
                GameView.Print(e.Message);
                return false;
            }

            return true;
        }
    }
}