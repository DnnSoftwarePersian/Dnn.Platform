<<<<<<< HEAD:Dnn.AdminExperience/Dnn.PersonaBar.Extensions/MenuControllers/ServersMenuController.cs
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
using System.Collections.Generic;
using Dnn.PersonaBar.Library.Controllers;
using Dnn.PersonaBar.Library.Model;
=======
﻿using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Dnn.PersonaBar.Library.Controllers;
using Dnn.PersonaBar.Library.Model;
using DotNetNuke.Common;
using DotNetNuke.Abstractions;
>>>>>>> Merges latest changes from 9.4.x into development (#3189):Dnn.AdminExperience/Extensions/Content/Dnn.PersonaBar.Extensions/MenuControllers/ExtensionMenuController.cs
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace Dnn.PersonaBar.Servers.MenuControllers
{
    public class ServersMenuController : IMenuItemController
    {
        protected INavigationManager NavigationManager { get; }
        public ExtensionMenuController()
        {
            NavigationManager = Globals.DependencyProvider.GetRequiredService<INavigationManager>();
        }

        public void UpdateParameters(MenuItem menuItem)
        {
            
        }

        public bool Visible(MenuItem menuItem)
        {
            var user = UserController.Instance.GetCurrentUserInfo();
            return user.IsSuperUser || user.IsInRole(PortalSettings.Current?.AdministratorRoleName);
        }

        public IDictionary<string, object> GetSettings(MenuItem menuItem)
        {
            var settings = new Dictionary<string, object>();
<<<<<<< HEAD:Dnn.AdminExperience/Dnn.PersonaBar.Extensions/MenuControllers/ServersMenuController.cs
=======
            settings.Add("portalId", PortalSettings.Current.PortalId);
            settings.Add("installUrl", NavigationManager.NavigateURL(PortalSettings.Current.ActiveTab.TabID, PortalSettings.Current, "Install", "popUp=true"));
>>>>>>> Merges latest changes from 9.4.x into development (#3189):Dnn.AdminExperience/Extensions/Content/Dnn.PersonaBar.Extensions/MenuControllers/ExtensionMenuController.cs
            return settings;
        }
    }
}
