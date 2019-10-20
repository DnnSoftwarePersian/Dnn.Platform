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
namespace DotNetNuke.Modules.HtmlEditorManager.Views
{
    using System;

    /// <summary>
    /// Contains information about the selected editor when saving
    /// </summary>
    public class EditorEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="EditorEventArgs" /> class.</summary>
        /// <param name="editor">The editor.</param>
        public EditorEventArgs(string editor)
        {
            this.Editor = editor;
        }

        /// <summary>Gets a value indicating whether this data comes from a valid form submission.</summary>
        public string Editor { get; private set; }
    }
}
