using System;
using NUnit.Framework;
using neuronic.Tests.Integration;

namespace neuronic.CLI.Tests.Integration
{
    [TestFixture(Category="Integration")]
    public class CLIReadIntegrationTestFixture : BaseIntegrationTestFixture
    {
        [Test]
        public void Test_Read()
        {
            CopyBinariesToTestDirectory ();

            var starter = new ProcessStarter ();

            var text = "The quick brown fox jumped over the lazy dog";

            starter.Start ("mono neuronic.exe read-text \"" + text + "\" --data neuronic-data");

            Assert.IsFalse (starter.IsError);

            // TODO: add more checks
        }
    }
}

