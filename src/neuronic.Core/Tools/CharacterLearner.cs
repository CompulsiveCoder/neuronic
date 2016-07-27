using System;
using System.Linq;
using System.Collections.Generic;

namespace neuronic.Core
{
    [Serializable]
    public class CharacterLearner
    {
        public CharacterFrequencyChecker Frequency = new CharacterFrequencyChecker();

        public CharacterLearner ()
        {
        }

        public void Learn(Brain brain, string text)
        {
            var characters = text.ToLower ().ToCharArray ();

            // The character map speeds up processing by using a dictionary instead of repeating linq queries
            var characterMap = GenerateCharacterMap (brain);

            var fraction = 1m / characters.Length;

            for (int i = 0; i < characters.Count(); i++)
            {
                Console.WriteLine (fraction * i + "%");
                Learn (brain, characters[i], characterMap);
                Frequency.CheckAndIncreaseFrequencyValues (brain, characters[i], characterMap);
            }

        }

        protected void Learn(Brain brain, char c, Dictionary<char, Neuron> characterMap)
        {
            if (characterMap == null)
                throw new ArgumentNullException ("characterMap");

            var characterNeuron = GetCharacterNeuron (c, characterMap);

            if (characterNeuron == null) {
                Console.WriteLine ("");
                AssignCharacterNeuron (brain, c, characterMap);
            }
            else
                Console.Write (".");
                //Console.WriteLine ("Character already exists: " + c);
        }

        public Neuron GetCharacterNeuron(char c, Dictionary<char, Neuron> characterMap)
        {
            if (characterMap.ContainsKey (c))
                return characterMap [c];
            else
                return null;
        }

        public Neuron GetCharacterNeuron(Brain brain, char c)
        {
            return (from n in brain.Neurons
                             where n.Concept == c.ToString ()
                select n).SingleOrDefault();
        }

        protected Neuron AssignCharacterNeuron(Brain brain, char c, Dictionary<char, Neuron> characterMap)
        {
            var neuron = brain.GetIdleNeuron ();

            Console.WriteLine ("Assigning character neuron: " + c);

            neuron.Concept = c.ToString();

            characterMap.Add (c, neuron);

            return neuron;
        }

        public Dictionary<char, Neuron> GenerateCharacterMap(Brain brain)
        {
            var dictionary = new Dictionary<char, Neuron> ();

            foreach (var neuron in brain.Neurons) {
                if (neuron.Concept != null && neuron.Concept.Length == 1) // TODO: Come up with a better way of filtering character only neurons
                    dictionary.Add (neuron.Concept.ToCharArray()[0], neuron);
            }

            return dictionary;
        }
    }
}

