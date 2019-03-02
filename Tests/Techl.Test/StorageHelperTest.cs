using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Techl.Test
{
    [TestClass]
    public class StorageHelperTest
    {
        [TestMethod]
        public void LocalPathTest()
        {
            Debug.WriteLine(StorageHelper.LocalPath);
        }
    }
}
