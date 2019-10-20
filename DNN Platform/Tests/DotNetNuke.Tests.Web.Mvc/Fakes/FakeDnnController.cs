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
using System.Web.Mvc;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System.Web.Routing;
using DotNetNuke.Tests.Web.Mvc.Fakes.Filters;
using System;

namespace DotNetNuke.Tests.Web.Mvc.Fakes
{
    public class FakeDnnController : DnnController
    {
        public ActionResult Action1()
        {
            return View("Action1");
        }

        public ActionResult Action2()
        {
            return View("Action2", "Master2");
        }

        public ActionResult Action3(Dog dog)
        {
            return View("Action3", "Master3", dog);
        }

        [FakeHandleExceptionRedirect]
        public ActionResult ActionWithExceptionFilter()
        {
            throw new Exception();
        }

        [FakeOnExecutingRedirect]
        public ActionResult ActionWithOnExecutingFilter()
        {
            return View("Action1");
        }

        [FakeOnExecutedRedirect]
        public ActionResult ActionWithOnExecutedFilter()
        {
            return View("Action1");
        }

        public void MockInitialize(RequestContext requestContext)
        {
            // Mocking out the entire MvcHandler and Controller lifecycle proved to be difficult
            // This method executes the initialization logic that occurs on every request which is
            // executed from the Execute method.
            Initialize(requestContext);
        }    
    }
}
