<<<<<<< HEAD:Dnn.AdminExperience/Dnn.PersonaBar.Extensions/MenuControllers/ExtensionMenuController.cs
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
=======
﻿using System.Collections.Generic;
>>>>>>> Revert "Merges latest changes from 9.4.x into development (#3189)":Dnn.AdminExperience/Extensions/Content/Dnn.PersonaBar.Extensions/MenuControllers/ExtensionMenuController.cs
using Dnn.PersonaBar.Library.Controllers;
using Dnn.PersonaBar.Library.Model;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace Dnn.PersonaBar.Extensions.MenuControllers
{
    public class ExtensionMenuController : IMenuItemController
    {
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
            settings.Add("portalId", PortalSettings.Current.PortalId);
            settings.Add("installUrl", Globals.NavigateURL(PortalSettings.Current.ActiveTab.TabID, PortalSettings.Current, "Install", "popUp=true"));
            return settings;
        }
    }
}