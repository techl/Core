using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Techl.IO;

namespace Techl.Test
{
    [TestClass]
    public class IniFileTest
    {
        IniFile File;

        [TestInitialize]
        public void Initialize()
        {
            var contents = @"
A=1
B=2

[Section1]
A=3
B=4

[Section2]
C=5.5
D=6
";
            System.IO.File.WriteAllText("Init.ini", contents);
            File = new IniFile(DirectoryHelper.GetBaseDirectory() + @"\Init.ini");
        }

        [TestMethod]
        public void IniFileOverallTest()
        {
            var value = File.Read("Section1", "A", "");
            Assert.IsTrue(value == "3");

            var value2 = File.Read("Section1", "B", 0);
            Assert.IsTrue(value2 == 4);

            var value3 = File.Read("Section2", "A", 0f);
            Assert.IsTrue(value3 == 0f);

            var value4 = File.Read("Section2", "C", 0f);
            Assert.IsTrue(value4 == 5.5f);

            // Write Test
            File.Write("Section2", "C", 6);

            value4 = File.Read("Section2", "C", 0f);
            Assert.IsTrue(value4 == 6);

            File.DeleteKey("Section1", "A");

            value = File.Read("Section1", "A", "");
            Assert.IsTrue(value == "");

            File.DeleteSection("Section2");

            value4 = File.Read("Section2", "C", 0f);
            Assert.IsTrue(value4 == 0);
        }
    }
}
