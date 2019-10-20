<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿#region Copyright
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
using DotNetNuke.Services.Localization;

namespace DotNetNuke.Web.Common
{
    public static class SharedConstants
    {
        public static readonly string RootFolder = null;
        public static readonly string HostRootFolder = null;
        public static readonly string Unspecified = null;

        static SharedConstants()
        {
            RootFolder = Localization.GetString("RootFolder.Name", Localization.SharedResourceFile);
            HostRootFolder = Localization.GetString("HostRootFolder.Name", Localization.SharedResourceFile);
            Unspecified = "<" + Localization.GetString("None_Specified", Localization.SharedResourceFile) + ">";
        }
    }
}
