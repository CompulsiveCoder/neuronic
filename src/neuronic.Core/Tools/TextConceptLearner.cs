using System;
using System.Linq;
using System.Collections.Generic;

namespace neuronic.Core
{
    public class TextConceptLearner
    {
        public int MaxConceptLength = 10;

        public TextConceptLearner ()
        {
        }

        public void LearnText(Brain brain, string text)
        {
        }

        protected void LearnText(Brain brain, string text, int conceptLength)
        {
            throw new NotImplementedException ();
            /*var concepts = ExtractConcepts (text, conceptLength);

            foreach (var concept in concepts.Keys)
            {
                if (!brain.KnowsConcept (concept))
                    brain.AssignConceptNeuron (concept);
            }*/
        }

        protected void ComprehendConcept(Brain brain, string concept)
        {
            var conceptNeuron = brain.GetConceptNeuron (concept);

            if (conceptNeuron == null)
                brain.AssignConceptNeuron (concept);
            else
                Console.WriteLine ("Concept already exists: " + concept);
        }
    }
}

