<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿#region Copyright
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
namespace DotNetNuke.Modules.HtmlEditorManager.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Model for provider configuration
    /// </summary>
    public class ProviderConfigurationViewModel
    {
        /// <summary>Gets or sets the editors.</summary>
        /// <value>The editors.</value>
        public List<string> Editors { get; set; }

        /// <summary>Gets or sets the selected editor.</summary>
        /// <value>The selected editor.</value>
        public string SelectedEditor { get; set; }

        /// <summary>Gets or sets a value indicating whether the provider can be saved.</summary>
        /// <value><c>true</c> if this instance can save; otherwise, <c>false</c>.</value>
        public bool CanSave { get; set; }
    }
}
