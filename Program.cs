using System.Text;

namespace HangmanGame
{
    class Program
    {
        public const int TRYS = 10;

        static void Main(string[] args)
        {
            GameView.Print("Hangman Game", "Send any text to start a new game.", "Guess one of our words");

            StartNewGame();
        }

        /// <summary>
        /// Start a new Hangman game.
        /// </summary>
        private static void StartNewGame()
        {
            GameView.Read();

            WordsModel model = new WordsModel();

            if (!model.GetWords())
            {
                return;
            };

            model.RefreshData();

            int trysLeft = TRYS;
            StringBuilder displayedTrys = new StringBuilder();

            GameView.PrintAfterClear($"Chances left: {trysLeft}", $"Word: {model.awnserEncrypted}");

            while (trysLeft != 0)
            {
                bool oneRight = false;

                string input = GameView.Read();

                while (!IsInputValid(input, model.awnserEncrypted, displayedTrys))
                {
                    GameView.Print("Please, make sure it's a letter and it was not informed before.");

                    input = GameView.Read();
                }

                for (int i = 0; i < model.awnser.Length; i++)
                {
                    if (!IsCharsEquals(input[0], model.awnser[i]))
                    {
                        continue;
                    }

                    model.ReplaceAwnserEncryptedChar(input, i);
                    oneRight = true;
                }

                if (!IsLeftAnyLetter(model.awnserEncrypted))
                {
                    GameView.PrintAfterClear("Congratulations, you won!",
                        $"The word was:  {model.awnser.ToUpper()}",
                        $"You had {trysLeft} chances left.",
                        "Send any text to startover.");

                    StartNewGame();
                    break;
                }

                if (!oneRight)
                {
                    trysLeft--;

                    if (!string.IsNullOrEmpty(displayedTrys.ToString()))
                    {
                        displayedTrys.Append(" - ");
                    }

                    displayedTrys.Append(input);
                }

                GameView.PrintAfterClear($"Chances left: {trysLeft}",
                    $"Word: {model.awnserEncrypted.ToString().ToUpper()}",
                    $"Your wrong inputs: {displayedTrys}");
            };

            if (trysLeft != 0)
            {
                return;
            }

            GameView.PrintAfterClear("GameOver", $"The word was: {model.awnser}", "Send any text to startover.");

            StartNewGame();
        }

        /// <summary>
        /// Validate if user's <paramref name="input"/> is a valid input by hangman game's rules.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="awnserEncrypted"></param>
        /// <param name="displayedTrys"></param>
        /// <returns></returns>
        private static bool IsInputValid(string input, StringBuilder awnserEncrypted, StringBuilder displayedTrys)
        {
            return input != default 
                && input.Length == 1 
                && char.IsLetter(input, 0) 
                && !awnserEncrypted.ToString().Contains(input)
                && !displayedTrys.ToString().Contains(input);
        }

        private static bool IsCharsEquals(char stInput, char ndInput)
        {
            return stInput.ToString().ToLower() == ndInput.ToString().ToLower();
        }

        /// <summary>
        /// Validate if there is still a letter to be found in <paramref name="awnserEncrypted"/>
        /// </summary>
        /// <param name="awnserEncrypted"></param>
        /// <returns></returns>
        private static bool IsLeftAnyLetter(StringBuilder awnserEncrypted)
        {
            return awnserEncrypted.ToString().Contains("_");
        }
    }
}