<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
=======
﻿#region Copyright
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
// All Rights Reserved
#endregion

>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
using System.Linq;
using DNN.Integration.Test.Framework.Helpers;

namespace DNN.Integration.Test.Framework.Controllers
{
    public class PermissionController
    {
        public static dynamic GetPermission(string code, string key)
        {
            const string query =
                @"SELECT * 
                  FROM {{objectQualifier}}Permission
                  WHERE PermissionCode = '{0}' AND PermissionKey = '{1}'";
            return DatabaseHelper.ExecuteDynamicQuery(string.Format(query, code, key)).SingleOrDefault();
        }
    }
}
