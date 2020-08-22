using Newtonsoft.Json;
using System;
using System.IO;

namespace HangmanGame
{
    /// <summary>
    /// To mock connection with a backend service.
    /// </summary>
    class DBController
    {
        /// <summary>
        /// Fetch json from project/bin/words.json
        /// </summary>
        /// <returns></returns>
        public static string[] FetchJSON()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            using (StreamReader r = new StreamReader(string.Concat(projectDirectory, "/words.json")))
            {
                string json = r.ReadToEnd();

                try
                {
                    return JsonConvert.DeserializeObject<string[]>(json);
                }
                catch
                {
                    throw new FileNotFoundException("Could not find words.json on project/bin folder or it may be on a wrong json format.");
                }
            }
        }
    }
}
