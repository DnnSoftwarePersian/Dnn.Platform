<<<<<<< HEAD
<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 

using DotNetNuke.Common;
=======
﻿using DotNetNuke.Common;
>>>>>>> Merges latest changes from 9.4.x into development (#3189)
using DotNetNuke.Abstractions;
using DotNetNuke.DependencyInjection;
using DotNetNuke.Entities.Portals;
=======
﻿using DotNetNuke.DependencyInjection;
>>>>>>> Revert "Merges latest changes from 9.4.x into development (#3189)"
using DotNetNuke.UI.Modules;
using DotNetNuke.UI.Modules.Html5;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetNuke
{
    public class Startup : IDnnStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WebFormsModuleControlFactory>();
            services.AddSingleton<Html5ModuleControlFactory>();
            services.AddSingleton<ReflectedModuleControlFactory>();
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> Merges latest changes from 9.4.x into development (#3189)
            services.AddTransient(x => PortalController.Instance);
            services.AddTransient<INavigationManager, NavigationManager>();
=======
>>>>>>> Revert "Merges latest changes from 9.4.x into development (#3189)"
        }
    }
}
