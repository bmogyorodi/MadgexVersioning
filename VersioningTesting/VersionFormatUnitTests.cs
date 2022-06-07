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


        public static void TestVersionFormatChecking(string version_number)
        {
 
         
                
                Assert.IsFalse(CheckVersionFormat(version_number));

        }

        [TestMethod]
        public void BasicVersionFormatRejection()
        {
            TestVersionFormatChecking("Any string that's not a version number");
        }
        [TestMethod]
        public void IncorrectVersionLengthCheck()
        {
            TestVersionFormatChecking("1.1.1.1.1");
        }

        [TestMethod]
        public void BadNumberFormatInVersionNumber()
        {
            TestVersionFormatChecking("1.02.1.1");
        }

        [TestMethod]
        public void DotAtTheEndOfVersionNumber()
        {
            TestVersionFormatChecking("1.1.1.1.");
        }

        [TestMethod]
        public void CheckRecievedBug()
        {
            TestVersionFormatChecking("1.2x3.4");
        }
    }
}
