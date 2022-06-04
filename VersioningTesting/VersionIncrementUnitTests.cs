using static versioning.VersionIncrement;

namespace VersionIncrementTesting
{
    [TestClass]
    public class VersionIncrementUnitTests
    {
        [TestMethod]
        public void FeatureVersionIncrementTest()
        {
            var version = IncrementFeatureVersion("1.1.2.3");
            Assert.AreEqual("1.1.3.0", version);
        }

        [TestMethod]
        public void BugFixVersionIncrementTest()
        {
            var version = IncrementFixVersion("1.1.2.3");
            Assert.AreEqual("1.1.2.4", version);
        }

        [TestMethod]
        public void CheckVersionFileReadingFunction()
        {
            const string testFile = "TestVersion1.cs";

            string fetchFromFile= GetLatestVersionNumber(testFile);
            
            Assert.AreEqual("1.4.5.2", fetchFromFile);

            
        }

        [TestMethod]
        public void CheckVersionFileWritingFunction()
        {

            const string testFile = "TestVersion2.cs";

            SaveVersionNumberChanges(testFile, "1.1.1.1");


            Assert.IsTrue(File.Exists(testFile));
            if (File.Exists(testFile))
            {
                using(StreamReader sr = new StreamReader(testFile))
                {
                   string? saved_version= sr.ReadLine();

                    Assert.AreEqual(saved_version, "1.1.1.1");
                }
                File.Delete(testFile);
            }
            Assert.IsTrue(!File.Exists(testFile));

        }

        
    }
}