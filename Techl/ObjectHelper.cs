using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techl
{
    public static class ObjectHelper
    {
        public static bool IsNullOrDBNull(this object obj)
        {
            return obj == null || obj == DBNull.Value;
        }
    }
}
