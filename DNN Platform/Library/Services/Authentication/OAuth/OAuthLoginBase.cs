<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿#region Copyright

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
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
#region Usings

using System;
using System.Collections.Specialized;
using System.Web;
using DotNetNuke.Common;

#endregion

namespace DotNetNuke.Services.Authentication.OAuth
{
    public abstract class OAuthLoginBase : AuthenticationLoginBase
    {
        protected virtual string AuthSystemApplicationName
        {
            get { return String.Empty; }
        }

        protected OAuthClientBase OAuthClient { get; set; }

        protected abstract UserData GetCurrentUser();

        protected virtual void AddCustomProperties(NameValueCollection properties)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                //Save the return Url in the cookie
                HttpContext.Current.Response.Cookies.Set(new HttpCookie("returnurl", RedirectURL)
                {
                    Expires = DateTime.Now.AddMinutes(5),
                    Path = (!string.IsNullOrEmpty(Globals.ApplicationPath) ? Globals.ApplicationPath : "/")
                });
            }

            bool shouldAuthorize = OAuthClient.IsCurrentService() && OAuthClient.HaveVerificationCode();
            if(Mode == AuthMode.Login)
            {
                shouldAuthorize = shouldAuthorize || OAuthClient.IsCurrentUserAuthorized();
            }

            if (shouldAuthorize)
            {
                if (OAuthClient.Authorize() == AuthorisationResult.Authorized)
                {
                    OAuthClient.AuthenticateUser(GetCurrentUser(), PortalSettings, IPAddress, AddCustomProperties, OnUserAuthenticated);
                }
            }
        }

        #region Overrides of AuthenticationLoginBase

        public override bool Enabled
        {
            get { return OAuthConfigBase.GetConfig(AuthSystemApplicationName, PortalId).Enabled; }
        }

        #endregion
    }
}
