using System;
using System.Collections.Generic;
using System.Linq;
using gitdb.Entities;
using gitdb.Data;
using System.IO;

namespace neuronic.Core
{
    [Serializable]
    public class Brain : BaseEntity
    {
        public CharacterLearner CharacterComprehension;

        public Neuron[] Neurons = new Neuron[]{};

        public Brain (int neuronCount)
        {
            Console.WriteLine ("Constructing new brain");

            CharacterComprehension = new CharacterLearner();

            CreateNeurons (neuronCount);
        }

        public void Read(string text)
        {
            Console.WriteLine ("Reading text");

            CharacterComprehension.Learn (this, text);
        }

        public void ReadTextFile(string filePath)
        {
            filePath = Path.GetFullPath (filePath);

            var reader = new StreamReader(filePath);

            String line;

            while((line = reader.ReadLine()) != null)
            {
                Read (line);
            }

            reader.Close();

        }

        public void CreateNeurons(int neuronCount)
        {
            var neurons = new List<Neuron> ();

            neurons.AddRange (Neurons);

            for (int i = 0; i < neuronCount; i++) {
                var neuron = new Neuron ();

                neurons.Add (neuron);
            }

            Neurons = neurons.ToArray ();
        }

        public Neuron GetIdleNeuron()
        {
            var availableNeurons = (from n in Neurons
                             where String.IsNullOrEmpty (n.Concept)
                select n).ToArray();

            if (availableNeurons.Length > 0)
                return availableNeurons [0];
            else
                throw new NoIdleNeuronsAvailableException ();
        }

        public Neuron GetConceptNeuron(string concept)
        {
            return (from n in Neurons
                where n.Concept == concept
                select n).SingleOrDefault();
        }

        public Neuron AssignConceptNeuron(string concept)
        {
            var neuron = GetIdleNeuron ();

            Console.WriteLine ("Assigning concept neuron: " + concept);

            neuron.Concept = concept;

            return neuron;
        }

        public bool KnowsConcept(string concept)
        {
            return GetConceptNeuron (concept) != null;
        }

        public void Save(string dataDirectory)
        {
            Console.WriteLine ("Saving brain to:");
            Console.WriteLine (dataDirectory);

            var data = new GitDB (dataDirectory);

            data.SaveOrUpdate (this);
        }

        public static Brain Load(string dataDirectory)
        {
            Console.WriteLine ("Loading brain from:");
            Console.WriteLine (dataDirectory);

            var data = new GitDB (dataDirectory);

            var brains = data.Get<Brain>();

            if (brains.Length != 1)
                throw new ArgumentException (brains.Length + " brains found in directory: " + dataDirectory);
            else
                return brains [0];
        }

        public static bool Exists(string dataDirectory)
        {
            var data = new GitDB (dataDirectory);

            return data.Get<Brain>().Length > 0;
        }
    }
}

