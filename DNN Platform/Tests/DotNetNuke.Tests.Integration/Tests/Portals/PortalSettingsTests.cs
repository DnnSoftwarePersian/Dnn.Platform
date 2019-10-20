﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
<<<<<<< HEAD
=======
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
// DEALINGS IN THE SOFTWARE.
#endregion

>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
using System;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Tests.Utilities;
using NUnit.Framework;

namespace DotNetNuke.Tests.Integration.Tests.Portals
{
    [TestFixture]
    public class PortalSettingsTests : DnnWebTest
    {
        private string _settingName;
        private string _settingValue;

        public PortalSettingsTests() : base(Constants.PORTAL_Zero)
        {
        }

        [SetUp]
        public void Setup()
        {
            _settingName = "NameToCheckFor";
            // we need different value so when we save we force going to database
            _settingValue = "ValueToCheckFor_" + new Random().Next(1, 100);
        }

        [Test]
        public void Saving_Non_Secure_Value_Doesnt_Encrypt_It()
        {
            //Act
            PortalController.UpdatePortalSetting(PortalId, _settingName, _settingValue, true, null, false);
            var result = PortalController.GetPortalSetting(_settingName, PortalId, "");

            //Assert
            Assert.AreNotEqual(result, "");
            Assert.AreEqual(_settingValue, result);
        }

        [Test]
        public void Saving_Secure_Value_Encrypts_It()
        {
            //Act
            PortalController.UpdatePortalSetting(PortalId, _settingName, _settingValue, true, null, true);

            var result = PortalController.GetPortalSetting(_settingName, PortalId, "");
            var decrypted = DotNetNuke.Security.FIPSCompliant.DecryptAES(result, Config.GetDecryptionkey(), Host.GUID);

            //Assert
            Assert.AreNotEqual(result, "");
            Assert.AreNotEqual(_settingValue, result);
            Assert.AreEqual(decrypted, _settingValue);
        }
    }
}
