using System;
using System.Collections.Generic;

namespace neuronic.Core
{
    public class TextConceptExtractor
    {
        public int MaxConceptLength = 10;

        public TextConceptExtractor ()
        {
        }

        public Dictionary<string, int> ExtractConcepts(string text)
        {
            var concepts = new Dictionary<string, int> ();

            for (int i = 1; i <= MaxConceptLength; i++)
            {
                var conceptsBlock = ExtractConcepts (text, i);
                foreach (var concept in conceptsBlock.Keys) {
                    if (concepts.ContainsKey (concept))
                        concepts [concept] += conceptsBlock [concept];
                    else
                        concepts.Add (concept, conceptsBlock[concept]);
                }
                // TODO: Remove if not needed
                /*foreach (var c in text.ToCharArray()) {
                    ComprehendConcept (brain, c);
                }*/

                // Frequency.CheckAndIncreaseFrequencyValues (brain, text);
            }

            return concepts;
        }

        public Dictionary<string, int> ExtractConcepts(string text, int conceptLength)
        {
            var concepts = new Dictionary<string, int> ();

            for (int i = 0; i < text.Length; i++) {
                var startPosition = i;
                var actualLength = conceptLength;
                if (actualLength + startPosition <= text.Length) {

                    var concept = text.Substring (startPosition, actualLength);

                    if (!concepts.ContainsKey (concept))
                        concepts.Add (concept, 1);
                    else
                        concepts [concept]++;
                }
            }

            return concepts;
        }
    }
}

