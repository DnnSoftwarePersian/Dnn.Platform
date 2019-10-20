<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿#region Copyright

// 
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2017
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
using DotNetNuke.ComponentModel;
using DotNetNuke.Data;
using DotNetNuke.Tests.Data.Fakes;

using NUnit.Framework;

namespace DotNetNuke.Tests.Data
{
    [TestFixture]
    public class DatabaseConnectionProviderTests
    {
        [Test]
        public void DatabaseConnectionProvider_Instance_Method_Returns_Instance()
        {
            //Arrange
            ComponentFactory.Container = new SimpleContainer();
            ComponentFactory.RegisterComponentInstance<DatabaseConnectionProvider>(new FakeDbConnectionProvider());

            //Act
            var provider = DatabaseConnectionProvider.Instance();

            //Assert
            Assert.IsInstanceOf<DatabaseConnectionProvider>(provider);
            Assert.IsInstanceOf<FakeDbConnectionProvider>(provider);
        }

        [Test]
        public void DatabaseConnectionProvider_Instance_Method_Returns_Same_Instances()
        {
            //Arrange
            ComponentFactory.Container = new SimpleContainer();
            ComponentFactory.RegisterComponentInstance<DatabaseConnectionProvider>(new FakeDbConnectionProvider());

            //Act
            var provider1 = DatabaseConnectionProvider.Instance();
            var provider2 = DatabaseConnectionProvider.Instance();

            //Assert
            Assert.IsInstanceOf<DatabaseConnectionProvider>(provider1);
            Assert.IsInstanceOf<DatabaseConnectionProvider>(provider2);
            Assert.AreSame(provider1, provider2);
        }
    }
}
