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
            File = new IniFile(DirectoryHelper.GetBaseDirectory() + @"\..\..\Init.ini");

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

            File.DeleteKey("Section1", "A");

        }

        [TestMethod]
        public void DeleteSectionTest()
        {
            File.DeleteSection("Section1");
        }
    }
}
