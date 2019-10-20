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
using System.Web.UI;

using DotNetNuke.Entities.Modules;

namespace DotNetNuke.UI.Modules
{
    public interface IModuleControlFactory
    {
        Control CreateControl(TemplateControl containerControl, string controlKey, string controlSrc);
        Control CreateModuleControl(TemplateControl containerControl, ModuleInfo moduleConfiguration);
        ModuleControlBase CreateModuleControl(ModuleInfo moduleConfiguration);
        Control CreateSettingsControl(TemplateControl containerControl, ModuleInfo moduleConfiguration, string controlSrc);
    }
}
