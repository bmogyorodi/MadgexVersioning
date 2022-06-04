using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static versioning.VersionIncrement;

namespace VersionIncrementTesting
{
    [TestClass]
    public class VersionFormatUnitTests
    {
        private void IncorrectVersionFormatSave(string version_number)
        {
            const string testFile = "TestVersion.cs";
            try
            {
                SaveVersionNumberChanges(testFile, version_number);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cannot save incorrect version number into file!", ex.Message);
            }

        }
        [TestMethod]
        public void BasicVersionFormatRejection()
        {
            IncorrectVersionFormatSave("Any string that's not a version number");
        }
        [TestMethod]
        public void IncorrectVersionLengthCheck()
        {
            IncorrectVersionFormatSave("1.1.1.1.1");
        }

        [TestMethod]
        public void BadNumberFormatInVersionNumber()
        {
            IncorrectVersionFormatSave("1.02.1.1");
        }

        [TestMethod]
        public void DotAtTheEndOfVersionNumber()
        {
            IncorrectVersionFormatSave("1.1.1.1.");
        }
    }
}
