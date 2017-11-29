// working
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techl.Data
{
    public interface IDBSource
    {
        string ConnectionString { get; }
    }
}
