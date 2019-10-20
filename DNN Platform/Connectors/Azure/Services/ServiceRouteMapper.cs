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
using DotNetNuke.Web.Api;

namespace Dnn.AzureConnector.Services
{
    public class ServiceRouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute routeManager)
        {
            routeManager.MapHttpRoute("AzureConnector",
                                      "default",
                                      "{controller}/{action}",
                                      new[] { "Dnn.AzureConnector.Services" });
        }
    }
}
