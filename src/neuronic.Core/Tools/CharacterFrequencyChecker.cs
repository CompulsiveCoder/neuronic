using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace neuronic.Core
{
    [Serializable]
    public class CharacterFrequencyChecker
    {
        public string FrequencyKey = "Frequency";

        public CharacterFrequencyChecker ()
        {
        }

        public void CheckAndIncreaseFrequencyValues(Brain brain, char character, Dictionary<char, Neuron> characterMap)
        {
            // TODO: Clean up
            // Use a character map to speed up the loop
            //var characterMap = brain.CharacterComprehension.GenerateCharacterMap (brain);

            //foreach (var c in text.ToCharArray()) {
                var neuron = brain.CharacterComprehension.GetCharacterNeuron (character, characterMap);

                if (neuron != null) {
                    if (!neuron.Values.ContainsKey (FrequencyKey))
                        neuron.Values [FrequencyKey] = 0;
                
                    neuron.Values [FrequencyKey]++;
                }
            //}
        }

        public KeyValuePair<char, decimal>[] GetCharactersSortedByFrequency(Brain brain)
        {
            EnsureFrequencyValuesSet (brain); // TODO: Should this check be here? It might slow down the process.

            var list = new SortedList<char, decimal> ();

            foreach (var n in brain.Neurons) {
                if (!String.IsNullOrEmpty(n.Concept))
                    list.Add (n.Concept.ToCharArray()[0], n.Values [FrequencyKey]);
            }

            return list.OrderByDescending (key => key.Value).ToArray();
        }

        public char GetMostFrequentCharacter(Brain brain)
        {
            EnsureFrequencyValuesSet (brain); // TODO: Should this check be here? It might slow down the process.

            var chars = GetCharactersSortedByFrequency(brain);
            return chars [0].Key;
        }

        public void EnsureFrequencyValuesSet(Brain brain)
        {
            var nonZeroNeurons = (from n in brain.Neurons
                where n.Values [FrequencyKey] > 0
                select n).ToArray();

            if (nonZeroNeurons.Length == 0)
                throw new Exception ("There are no non-zero \"Frequency\" values. Use the CheckAndIncreaseFrequencyValues function first.");
            
        }
    }
}

