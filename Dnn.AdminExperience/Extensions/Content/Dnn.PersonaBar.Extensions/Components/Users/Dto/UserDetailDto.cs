﻿#region Copyright
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

using System;
using System.Linq;
using System.Runtime.Serialization;
<<<<<<< HEAD
=======
using Microsoft.Extensions.DependencyInjection;
>>>>>>> update form orginal repo
using Dnn.PersonaBar.Library.Common;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.FileSystem;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
<<<<<<< HEAD
=======
using DotNetNuke.Abstractions;
>>>>>>> update form orginal repo

namespace Dnn.PersonaBar.Users.Components.Dto
{
    [DataContract]
    public class UserDetailDto : UserBasicDto
    {
        [DataMember(Name = "lastLogin")]
        public DateTime LastLogin { get; set; }

        [DataMember(Name = "lastActivity")]
        public DateTime LastActivity { get; set; }

        [DataMember(Name = "lastPasswordChange")]
        public DateTime LastPasswordChange { get; set; }

        [DataMember(Name = "lastLockout")]
        public DateTime LastLockout { get; set; }

        [DataMember(Name = "isOnline")]
        public bool IsOnline { get; set; }

        [DataMember(Name = "isLocked")]
        public bool IsLocked { get; set; }

        [DataMember(Name = "needUpdatePassword")]
        public bool NeedUpdatePassword { get; set; }

        [IgnoreDataMember]
        public int PortalId { get; set; }


        [DataMember(Name = "profileUrl")]
        public string ProfileUrl => UserId > 0 ? Globals.UserProfileURL(UserId) : null;

        [DataMember(Name = "editProfileUrl")]
        public string EditProfileUrl => UserId > 0 ? GetSettingUrl(PortalId, UserId) : null;

        [DataMember(Name = "userFolder")]
        public string UserFolder { get; set; }

        [DataMember(Name = "userFolderId")]
        public int UserFolderId { get; set; }

        [DataMember(Name = "hasUserFiles")]
        public bool HasUserFiles { get; set; }

        [DataMember(Name = "hasAgreedToTermsOn")]
        public DateTime HasAgreedToTermsOn { get; set; }

<<<<<<< HEAD
        public UserDetailDto()
        {
            
=======
        private static readonly INavigationManager _navigationManager = Globals.DependencyProvider.GetRequiredService<INavigationManager>();

        public UserDetailDto()
        {
>>>>>>> update form orginal repo
        }

        public UserDetailDto(UserInfo user) : base(user)
        {
            LastLogin = user.Membership.LastLoginDate;
            LastActivity = user.Membership.LastActivityDate;
            LastPasswordChange = user.Membership.LastPasswordChangeDate;
            LastLockout = user.Membership.LastLockoutDate;
            IsOnline = user.Membership.IsOnLine;
            IsLocked = user.Membership.LockedOut;
            NeedUpdatePassword = user.Membership.UpdatePassword;
            PortalId = user.PortalID;
            UserFolder = FolderManager.Instance.GetUserFolder(user).FolderPath.Substring(6);
            var userFolder = FolderManager.Instance.GetUserFolder(user);
            if (userFolder != null)
            {
                UserFolderId = userFolder.FolderID;

                //check whether user had upload files
                var files = FolderManager.Instance.GetFiles(userFolder, true);
                HasUserFiles = files.Any();
            }
            HasAgreedToTermsOn = user.HasAgreedToTermsOn;
        }

        private static string GetSettingUrl(int portalId, int userId)
        {
            var module = ModuleController.Instance.GetModulesByDefinition(UserController.Instance.GetUserById(portalId, userId).IsSuperUser ? -1 : portalId, "User Accounts")
                .Cast<ModuleInfo>().FirstOrDefault();
            if (module == null)
            {
                return string.Empty;
            }

            var tabId = TabController.Instance.GetTabsByModuleID(module.ModuleID).Keys.FirstOrDefault();
            if (tabId <= 0)
            {
                return string.Empty;
            }
            //ctl/Edit/mid/345/packageid/52
<<<<<<< HEAD
            return Globals.NavigateURL(tabId, PortalSettings.Current, "Edit",
=======
            return _navigationManager.NavigateURL(tabId, PortalSettings.Current, "Edit",
>>>>>>> update form orginal repo
                                            "mid=" + module.ModuleID,
                                            "popUp=true",
                                            "UserId=" + userId,
                                            "editprofile=true");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> update form orginal repo
