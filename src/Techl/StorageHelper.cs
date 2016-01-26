// Copyright (c) techl.com All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Microsoft.Extensions.PlatformAbstractions;
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
#if DOTNET5_4
                var appEnv = CallContextServiceLocator.Locator.ServiceProvider.GetService(typeof(IApplicationEnvironment)) as IApplicationEnvironment;
                return appEnv.ApplicationBasePath;
                //return global::Windows.Storage.ApplicationData.Current.LocalFolder.Path;
#else
                return AppDomain.CurrentDomain.BaseDirectory;
#endif
            }
        }
    }
}
