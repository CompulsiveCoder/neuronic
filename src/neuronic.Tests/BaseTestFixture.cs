using System;
using NUnit.Framework;
using System.IO;

namespace neuronic.Tests
{
    public abstract class BaseTestFixture
    {
        public string ProjectDirectory;
        public string OriginalDirectory;
        public string TemporaryDirectory;

        public bool DeleteTemporaryDirectory = true;

        public BaseTestFixture ()
        {
        }

        [SetUp]
        public void SetUp()
        {
            OriginalDirectory = Environment.CurrentDirectory;

            var tmpDirCreator = new TemporaryDirectoryCreator ();

            TemporaryDirectory = tmpDirCreator.Create ();
            ProjectDirectory = tmpDirCreator.GetProjectDirectory ();

            Directory.SetCurrentDirectory (TemporaryDirectory);

            Console.WriteLine ("Current directory:");
            Console.WriteLine (TemporaryDirectory);
            Console.WriteLine ();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine ("Cleaning up...");

            Directory.SetCurrentDirectory (OriginalDirectory);

            if (DeleteTemporaryDirectory && TemporaryDirectory.ToLower().Contains("-tmp")) {
                Directory.Delete (TemporaryDirectory, true);
            }
        }

        public void CopyBinariesToTestDirectory()
        {
            var mode = "Release";

            #if DEBUG
            mode = "Debug";
            #endif

            var binDir = OriginalDirectory;

            foreach (var file in Directory.GetFiles(binDir)) {
                var newPath = file.Replace (OriginalDirectory, TemporaryDirectory);

                File.Copy (file, newPath);
            }
        }
    }
}

