<<<<<<< HEAD
<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
=======
=======
>>>>>>> update form orginal repo
﻿#region Copyright
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
// All Rights Reserved
#endregion

<<<<<<< HEAD
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
=======
>>>>>>> update form orginal repo
using System;

namespace DotNetNuke.Providers.FolderProviders.Components
{
    public interface IRemoteStorageItem
    {
        string Key { get; }
        DateTime LastModified { get; }
        long Size { get; }

        string HashCode { get; }
    }
}
