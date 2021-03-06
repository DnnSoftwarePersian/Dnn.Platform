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

using System;
using System.Web.UI.WebControls;
<<<<<<< HEAD

using DotNetNuke.Common;
=======
using Microsoft.Extensions.DependencyInjection;

using DotNetNuke.Common;
using DotNetNuke.Abstractions;
>>>>>>> update form orginal repo
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Host;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.FileSystem;

#endregion

namespace DotNetNuke.UI.Skins.Controls
{
    /// -----------------------------------------------------------------------------
    /// <summary></summary>
    /// <returns></returns>
    /// <remarks></remarks>
    /// -----------------------------------------------------------------------------
    public partial class Logo : SkinObjectBase
    {
<<<<<<< HEAD
        public string BorderWidth { get; set; }
        public string CssClass { get; set; }
=======
        private readonly INavigationManager _navigationManager;
        public string BorderWidth { get; set; }
        public string CssClass { get; set; }

        public Logo()
        {
            _navigationManager = Globals.DependencyProvider.GetRequiredService<INavigationManager>();
        }

>>>>>>> update form orginal repo
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                if (!String.IsNullOrEmpty(BorderWidth))
                {
                    imgLogo.BorderWidth = Unit.Parse(BorderWidth);
                }
                if (!String.IsNullOrEmpty(CssClass))
                {
                    imgLogo.CssClass = CssClass;
                }
                bool logoVisible = false;
                if (!String.IsNullOrEmpty(PortalSettings.LogoFile))
                {
                    var fileInfo = GetLogoFileInfo();
                    if (fileInfo != null)
                    {
                        string imageUrl = FileManager.Instance.GetUrl(fileInfo);
                        if (!String.IsNullOrEmpty(imageUrl))
                        {
                            imgLogo.ImageUrl = imageUrl;
                            logoVisible = true;
                        }
                    }
                }
                imgLogo.Visible = logoVisible;
                imgLogo.AlternateText = PortalSettings.PortalName;
                hypLogo.ToolTip = PortalSettings.PortalName;

                if (!imgLogo.Visible)
                {
                    hypLogo.Attributes.Add("aria-label", PortalSettings.PortalName);
                }
                if (PortalSettings.HomeTabId != -1)
                {
<<<<<<< HEAD
                    hypLogo.NavigateUrl = Globals.NavigateURL(PortalSettings.HomeTabId);
=======
                    hypLogo.NavigateUrl = _navigationManager.NavigateURL(PortalSettings.HomeTabId);
>>>>>>> update form orginal repo
                }
                else
                {
                    hypLogo.NavigateUrl = Globals.AddHTTP(PortalSettings.PortalAlias.HTTPAlias);
                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private IFileInfo GetLogoFileInfo()
        {
            string cacheKey = String.Format(DataCache.PortalCacheKey, PortalSettings.PortalId, PortalSettings.CultureCode) + "LogoFile";
            var file = CBO.GetCachedObject<FileInfo>(new CacheItemArgs(cacheKey, DataCache.PortalCacheTimeOut, DataCache.PortalCachePriority),
                                                    GetLogoFileInfoCallBack);

            return file;
        }

        private IFileInfo GetLogoFileInfoCallBack(CacheItemArgs itemArgs)
        {
            return FileManager.Instance.GetFile(PortalSettings.PortalId, PortalSettings.LogoFile);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> update form orginal repo
