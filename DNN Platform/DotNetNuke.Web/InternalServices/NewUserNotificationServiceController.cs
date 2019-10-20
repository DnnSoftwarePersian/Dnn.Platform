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
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Common;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Social.Notifications;
using DotNetNuke.Web.Api;
using DotNetNuke.Services.Mail;

namespace DotNetNuke.Web.InternalServices
{
    [DnnAuthorize]
    public class NewUserNotificationServiceController : DnnApiController
    {        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage Authorize(NotificationDTO postData)
        {
            var user = GetUser(postData);
            if (user == null)
            {
                NotificationsController.Instance.DeleteNotification(postData.NotificationId);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "User not found");
            }

            user.Membership.Approved = true;
            UserController.UpdateUser(PortalSettings.PortalId, user);

            //Update User Roles if needed
            if (!user.IsSuperUser && user.IsInRole("Unverified Users") && PortalSettings.UserRegistration == (int)Globals.PortalRegistrationType.VerifiedRegistration)
            {
                UserController.ApproveUser(user);
            }

            Mail.SendMail(user, MessageType.UserAuthorized, PortalSettings);

            return Request.CreateResponse(HttpStatusCode.OK, new { Result = "success" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage Reject(NotificationDTO postData)
        {
            var user = GetUser(postData);
            if (user == null)
            {
                NotificationsController.Instance.DeleteNotification(postData.NotificationId);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "User not found");
            }

            UserController.RemoveUser(user);

            return Request.CreateResponse(HttpStatusCode.OK, new { Result = "success" });
        }

        [HttpPost]
        [DnnAuthorize]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage SendVerificationMail(NotificationDTO postData)
        {
            if (UserInfo.Membership.Approved)
            {
                throw new UserAlreadyVerifiedException();
            }

            if (!UserInfo.IsInRole("Unverified Users"))
            {
                throw new InvalidVerificationCodeException();
            }

            var message = Mail.SendMail(UserInfo, MessageType.UserRegistrationVerified, PortalSettings);
            if (string.IsNullOrEmpty(message))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new {Result = Localization.GetSafeJSString("VerificationMailSendSuccessful", Localization.SharedResourceFile) });
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
        }

        private UserInfo GetUser(NotificationDTO notificationDto)
        {
            var notification = NotificationsController.Instance.GetNotification(notificationDto.NotificationId);

            int userId;
            if (!int.TryParse(notification.Context, out userId))
            {
                return null;
            }

            return UserController.GetUserById(PortalSettings.PortalId, userId);            
        }
    }
}
