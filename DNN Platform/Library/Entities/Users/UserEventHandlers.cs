<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿#region Copyright

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
using System.ComponentModel.Composition;
using System.Globalization;
using DotNetNuke.Services.Mail;
using DotNetNuke.Services.Social.Notifications;

namespace DotNetNuke.Entities.Users
{
    [Export(typeof(IUserEventHandlers))]
    public class UserEventHandlers : IUserEventHandlers
    {
        public void UserAuthenticated(object sender, UserEventArgs args)
        {
        }

        public void UserCreated(object sender, UserEventArgs args)
        {
            UserRegistrationEmailNotifier.NotifyAdministrator(args.User);

            if (args.SendNotification)
            {
                UserRegistrationEmailNotifier.NotifyUser(args.User);
            }
        }

        public void UserRemoved(object sender, UserEventArgs args)
        {
            DeleteAllNewUnauthorizedUserRegistrationNotifications(args.User.UserID);
        }

        public void UserDeleted(object sender, UserEventArgs args)
        {
        }

        public void UserApproved(object sender, UserEventArgs args)
        {
            if (args.SendNotification)
            {
                UserRegistrationEmailNotifier.NotifyUser(args.User, MessageType.UserRegistrationPublic);
            }
            DeleteAllNewUnauthorizedUserRegistrationNotifications(args.User.UserID);
        }

        public void UserUpdated(object sender, UpdateUserEventArgs args)
        {
        }

        private static void DeleteAllNewUnauthorizedUserRegistrationNotifications(int userId)
        {
            var nt = NotificationsController.Instance.GetNotificationType("NewUnauthorizedUserRegistration");
            var notifications = NotificationsController.Instance.GetNotificationByContext(nt.NotificationTypeId, userId.ToString(CultureInfo.InvariantCulture));

            foreach (var notification in notifications)
            {
                NotificationsController.Instance.DeleteNotification(notification.NotificationID);
            }
        }
    }
}
