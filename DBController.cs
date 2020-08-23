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
        // TODO: add a better approach on how to handle idiom in a non hard coded way w/ json files
        private static Idiom currentIdiom = Idiom.Portuguese;

        enum Idiom
        {
            Portuguese,
            English
        }
        /// <summary>
        /// Fetch json from project/bin/words.json
        /// </summary>
        /// <returns></returns>
        public static string[] FetchJSON()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string jsonDirectory = string.Concat(projectDirectory, currentIdiom == Idiom.English ? "/words.json" : "/words-portuguese.json");
            using (StreamReader r = new StreamReader(jsonDirectory))
            {
                string json = r.ReadToEnd();

                try
                {
                    return JsonConvert.DeserializeObject<string[]>(json);
                }
                catch(Exception e)
                {
                    throw new FileNotFoundException("Could not find words.json on project/bin folder or it may be on a wrong json format.");
                }
            }
        }
    }
}                          