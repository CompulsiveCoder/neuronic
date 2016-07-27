using System;
using NUnit.Framework;

namespace neuronic.Core.Tests.Integration
{
    [TestFixture(Category="Integration")]
    public class BrainIntegrationTestFixture
    {
        [Test]
        public void Test_Read()
        {
            var brain = new Brain (100);

            var text = "The quick brown fox jumped over the lazy dog";

            brain.Read (text);

            // TODO: Add asserts
            //throw new NotImplementedException ();
        }
    }
}

