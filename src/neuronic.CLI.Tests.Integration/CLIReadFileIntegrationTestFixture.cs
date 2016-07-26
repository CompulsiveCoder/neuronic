using System;
using NUnit.Framework;
using neuronic.Tests.Integration;
using System.IO;

namespace neuronic.CLI.Tests.Integration
{
    [TestFixture(Category="Integration")]
    public class CLIReadFileIntegrationTestFixture : BaseIntegrationTestFixture
    {
        [Test]
        public void Test_ReadFile()
        {
            CopyBinariesToTestDirectory ();

            var starter = new ProcessStarter ();

            var text = "The quick brown fox jumped over the lazy dog";

            var fileName = "textfile.txt";

            var filePath = Path.GetFullPath (fileName);

            File.WriteAllText (filePath, text);

            starter.Start ("mono neuronic.exe read-text-file \"" + fileName + "\" --data neuronic-data");

            Assert.IsFalse (starter.IsError);

            // TODO: add more checks
        }
    }
}

