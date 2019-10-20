<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿#region Copyright

// 
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
using System;
using System.Collections.Generic;

namespace DotNetNuke.Entities.Host
{
    /// <summary>
    /// Do not implement.  This interface is meant for reference and unit test purposes only.
    /// There is no guarantee that this interface will not change.
    /// </summary>
    public interface IIPFilterController
    {
        int AddIPFilter(IPFilterInfo ipFilter);

        void UpdateIPFilter(IPFilterInfo ipFilter);

        void DeleteIPFilter(IPFilterInfo ipFilter);

        IPFilterInfo GetIPFilter(int ipFilter);

        IList<IPFilterInfo> GetIPFilters();

        bool IsIPBanned(string ipAddress);

        bool IsAllowableDeny(string ipAddress, IPFilterInfo ipFilter);

        bool CanIPStillAccess(string myip, IList<IPFilterInfo> filterList);
    }
}
