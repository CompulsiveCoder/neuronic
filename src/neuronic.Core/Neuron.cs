using System;
using System.Collections;
using System.Collections.Generic;

namespace neuronic.Core
{
    [Serializable]
    public class Neuron
    {
        public string Concept { get; set; }

        public Dictionary<string, decimal> Values = new Dictionary<string, decimal> ();

        public Neuron ()
        {
            Values.Add ("Frequency", 0);
        }
    }
}

