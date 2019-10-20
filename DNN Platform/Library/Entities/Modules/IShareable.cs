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
namespace DotNetNuke.Entities.Modules
{
    public interface IShareable
    {
        /// <summary>Does this module support Module Sharing (i.e., sharing modules between sites within a SiteGroup)?</summary>
        ModuleSharing SharingSupport { get; set; }
    }
}
