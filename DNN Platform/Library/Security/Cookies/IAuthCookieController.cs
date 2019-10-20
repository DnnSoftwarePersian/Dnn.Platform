<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
using System;

namespace DotNetNuke.Security.Cookies
{
    public interface IAuthCookieController
    {
        void Update(string cookieValue, DateTime utcExpiry, int userId);
        PersistedAuthCookie Find(string cookieValue);
        void DeleteByValue(string cookieValue);
        void DeleteExpired(DateTime utcExpiredBefore);
    }
}
