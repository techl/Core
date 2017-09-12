// Copyright (c) techl.com All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techl.IO
{
    public enum ContentTypes
    {
        [Display(Description = "application/vnd.ms-excel")]
        XLS,
        [Display(Description = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        XLSX
    }
}
