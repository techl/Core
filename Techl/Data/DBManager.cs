// Copyright (c) techl.com All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techl.Data
{
    public class DBManager
    {
        public static IDBSource DBSource { get; set; }

        public static string GetConnectionString()
        {
            if (DBSource != null)
                return DBSource.ConnectionString;
            else
                throw new InvalidOperationException("DBSource is not initialized.");
        }

        public static void SetConnectionString(string connectionString)
        {
            DBSource = new DBSource() { ConnectionString = connectionString };
        }
    }
}
