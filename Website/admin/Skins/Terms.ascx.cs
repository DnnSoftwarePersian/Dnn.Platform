#region Copyright
<<<<<<< HEAD
// 
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
=======
//
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
>>>>>>> update form orginal repo
// DEALINGS IN THE SOFTWARE.
#endregion
#region Usings

using DotNetNuke.Common;
<<<<<<< HEAD
=======
using DotNetNuke.Abstractions;
>>>>>>> update form orginal repo
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using System;
<<<<<<< HEAD
=======
using Microsoft.Extensions.DependencyInjection;
>>>>>>> update form orginal repo

#endregion

namespace DotNetNuke.UI.Skins.Controls
{
    /// -----------------------------------------------------------------------------
    /// <summary></summary>
    /// <returns></returns>
    /// <remarks></remarks>
    /// -----------------------------------------------------------------------------
    public partial class Terms : SkinObjectBase
    {
<<<<<<< HEAD
=======
        private readonly INavigationManager _navigationManager;
>>>>>>> update form orginal repo
        private const string MyFileName = "Terms.ascx";
        public string Text { get; set; }

        public string CssClass { get; set; }

<<<<<<< HEAD
=======
        public Terms()
        {
            _navigationManager = Globals.DependencyProvider.GetRequiredService<INavigationManager>();
        }

>>>>>>> update form orginal repo
        private void InitializeComponent()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                if (!String.IsNullOrEmpty(CssClass))
                {
                    hypTerms.CssClass = CssClass;
                }
                if (!String.IsNullOrEmpty(Text))
                {
                    hypTerms.Text = Text;
                }
                else
                {
                    hypTerms.Text = Localization.GetString("Terms", Localization.GetResourceFile(this, MyFileName));
                }
<<<<<<< HEAD
                hypTerms.NavigateUrl = PortalSettings.TermsTabId == Null.NullInteger ? Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "Terms") : Globals.NavigateURL(PortalSettings.TermsTabId);
=======
                hypTerms.NavigateUrl = PortalSettings.TermsTabId == Null.NullInteger ? _navigationManager.NavigateURL(PortalSettings.ActiveTab.TabID, "Terms") : _navigationManager.NavigateURL(PortalSettings.TermsTabId);
>>>>>>> update form orginal repo

                hypTerms.Attributes["rel"] = "nofollow";
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> update form orginal repo
