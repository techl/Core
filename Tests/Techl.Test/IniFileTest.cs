using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Techl.IO;

namespace Techl.Test
{
    [TestClass]
    public class IniFileTest
    {
        [TestMethod]
        public void IniFileTest()
        {
            var file = new IniFile(DirectoryHelper.GetBaseDirectory() + @"\..\..\Init.ini");
            var value = file.Read("Section1", "A", "");
            Assert.IsTrue(value == "3");

            var value2 = file.Read("Section1", "B", 0);
            Assert.IsTrue(value2 == 4);

            var value3 = file.Read("Section2", "A", 0f);
            Assert.IsTrue(value3 == 0f);

            var value4 = file.Read("Section2", "C", 0f);
            Assert.IsTrue(value4 == 5.5f);
        }
    }
}
