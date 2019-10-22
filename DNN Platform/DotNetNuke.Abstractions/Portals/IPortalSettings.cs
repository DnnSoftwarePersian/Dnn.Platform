<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
// Licensed to the .NET Foundation under one or more agreements.
=======
﻿// Licensed to the .NET Foundation under one or more agreements.
>>>>>>> Merges latest changes from 9.4.x into development (#3189)
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information. 

namespace DotNetNuke.Abstractions.Portals
{
    public interface IPortalSettings
    {
        int PortalId { get; }
        bool ContentLocalizationEnabled { get; }
        bool EnableUrlLanguage { get; }
        bool SSLEnabled { get; }
        string SSLURL { get; }
    }
}
