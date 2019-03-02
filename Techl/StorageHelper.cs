using System;
using System.Collections.Generic;
using System.Text;

namespace Techl
{
    public static class StorageHelper
    {
        public static string LocalPath
        {
            get
            {
                return AppContext.BaseDirectory;
            }
        }
    }
}
