using System;
using NUnit.Framework;
using System.Linq;

namespace neuronic.Core.Tests.Unit
{
    [TestFixture(Category="Unit")]
    public class CharacterFrequencyCheckerUnitTestFixture
    {
        [Test]
        public void Test_GetMostFrequentCharacter()
        {
            Console.WriteLine ("");
            Console.WriteLine ("=== Prepare Test ===");
            Console.WriteLine ("");

            var brain = new Brain (100);

            var text = "The quick brown fox jumped over the lazy dog";

            // TODO: Mock this section
            brain.Read (text);

            var checker = brain.CharacterComprehension.Frequency;

            //checker.CheckAndIncreaseFrequencyValues (brain, text);

            Console.WriteLine ("");
            Console.WriteLine ("=== Run Test ===");
            Console.WriteLine ("");

            var mostFrequentCharacter = checker.GetMostFrequentCharacter (brain);

            Console.WriteLine ("");
            Console.WriteLine ("=== Check Test ===");
            Console.WriteLine ("");

            Assert.AreEqual (' ', mostFrequentCharacter);
        }

        [Test]
        public void Test_GetCharactersSortedByFrequency()
        {
            Console.WriteLine ("");
            Console.WriteLine ("=== Prepare Test ===");
            Console.WriteLine ("");

            var brain = new Brain (100);

            var text = "The quick brown fox jumped over the lazy dog";

            // TODO: Mock this section
            brain.Read (text);

            var checker = brain.CharacterComprehension.Frequency;

            //checker.CheckAndIncreaseFrequencyValues (brain, text);

            Console.WriteLine ("");
            Console.WriteLine ("=== Run Test ===");
            Console.WriteLine ("");

            var characters = checker.GetCharactersSortedByFrequency (brain);

            Console.WriteLine ("");
            Console.WriteLine ("=== Check Test ===");
            Console.WriteLine ("");

            Assert.AreEqual (" ", characters[0].Key.ToString());
            Assert.AreEqual (8, characters[0].Value);

            Assert.AreEqual ("e", characters[1].Key.ToString());
            Assert.AreEqual (4, characters[1].Value);

            Assert.AreEqual ("o", characters[2].Key.ToString());
            Assert.AreEqual (4, characters[2].Value);
        }
    }
}

