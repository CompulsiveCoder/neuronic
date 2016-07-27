using System;
using neuronic.Core;
using System.IO;

namespace neuronic.CLI
{
    class MainClass
    {
        public static Brain CurrentBrain;

        public static void Main (string[] args)
        {
            var arguments = new Arguments (args);

            CurrentBrain = GetBrain (arguments);

            var dataDir = GetDataDirectory (arguments);


            if (arguments.KeylessArguments.Length == 0)
                Help ();
            else
            {
                var command = arguments.KeylessArguments [0];

                switch (command) {
                case "read-text":
                    ReadText (arguments);
                    break;
                case "read-text-file":
                    ReadTextFile (arguments);
                    break;
                case "list-common-characters":
                    ListCommonCharacters (arguments);
                    break;
                default:
                    Help ();
                    break;
                }
            }
        }

        public static Brain GetBrain(Arguments arguments)
        {
            var neuronCount = 100; // TODO: Make it easy to customize this value via an argument

            var dataDir = GetDataDirectory (arguments);

            var brainFound = !String.IsNullOrEmpty (dataDir)
                             && Directory.Exists (dataDir)
                && Brain.Exists(dataDir);

            if (brainFound)
                return Brain.Load (dataDir);
            else
                return new Brain (neuronCount);
        }

        public static void ReadText(Arguments arguments)
        {
            var text = arguments.KeylessArguments [1];

            CurrentBrain.Read (text);

            var dataDir = GetDataDirectory (arguments);

            if (!String.IsNullOrEmpty(dataDir))
            {
                CurrentBrain.Save (dataDir);
            }

        }

        public static void ReadTextFile(Arguments arguments)
        {
            var file = arguments.KeylessArguments [1];

            file = Path.GetFullPath (file);

            CurrentBrain.ReadTextFile (file);

            var dataDir = GetDataDirectory (arguments);

            if (!String.IsNullOrEmpty(dataDir))
            {
                CurrentBrain.Save (dataDir);
            }
        }

        public static void ListCommonCharacters(Arguments arguments)
        {
            var characterEntries = CurrentBrain.CharacterComprehension.Frequency.GetCharactersSortedByFrequency (CurrentBrain);


            foreach (var entry in characterEntries) {
                var keyText = entry.Key.ToString();
                if (keyText == " ")
                    keyText = "[space]";
                if (keyText == "\n")
                    keyText = "[\\n]";
                Console.WriteLine (keyText + ": " + (int)entry.Value);
            }
        }

        public static void Help()
        {
            throw new NotImplementedException ();
        }

        public static string GetDataDirectory(Arguments arguments)
        {
            if (arguments.Contains ("data"))
                return Path.GetFullPath (arguments ["data"]);
            else
                return String.Empty;
        }
    }
}
