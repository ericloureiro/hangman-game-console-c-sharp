using System;
using System.Text;

namespace HangmanGame
{
    /// <summary>
    /// To mock a view from a frontend service.
    /// </summary>
    public static class GameView
    {
        /// <summary>
        /// Print to console <paramref name="content"/> in separated lines .
        /// </summary>
        /// <param name="content"></param>
        public static void Print(params string[] content)
        {
            StringBuilder formattedContent = new StringBuilder();

            foreach (string line in content)
            {
                formattedContent.AppendLine(line);
            }

            // Remove last empty line.
            formattedContent.Remove(formattedContent.Length - 1, 1);

            Console.WriteLine(formattedContent);
        }

        /// <summary>
        /// Read one line from console.
        /// </summary>
        /// <returns></returns>
        public static string Read()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Clear console.
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Clear console then print.
        /// </summary>
        /// <param name="content"></param>
        public static void PrintAfterClear(params string[] content)
        {
            Clear();

            Print(content);
        }
    }
}