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
using System;
using System.Web.Mvc;
using System.Web.Routing;
using DotNetNuke.Web.Mvc.Framework.ActionResults;
using NUnit.Framework;

namespace DotNetNuke.Tests.Web.Mvc
{
    public static class ResultAssert
    {
        public static void IsEmpty(ActionResult result)
        {
            Assert.IsInstanceOf<EmptyResult>(result);
        }

        public static void IsUnauthorized(ActionResult result)
        {
            Assert.IsInstanceOf<HttpUnauthorizedResult>(result);
        }

        public static void IsView(ActionResult result, string viewName)
        {
            IsView(result, viewName, String.Empty, new RouteValueDictionary());
        }

        public static void IsView(ActionResult result, string viewName, string masterName, RouteValueDictionary expectedViewData)
        {
            ViewResult viewResult = result.AssertCast<ViewResult>();
            StringsEqualOrBothNullOrEmpty(viewName, viewResult.ViewName);
            StringsEqualOrBothNullOrEmpty(viewName, viewResult.ViewName);

            DictionaryAssert.ContainsEntries(expectedViewData, viewResult.ViewData);
        }
        private static TCast AssertCast<TCast>(this ActionResult result) where TCast : class
        {
            var castResult = result as TCast;
            Assert.IsNotNull(castResult);
            return castResult;
        }

        private static void StringsEqualOrBothNullOrEmpty(string expected, string actual)
        {
            if (String.IsNullOrEmpty(expected))
            {
                Assert.IsTrue(String.IsNullOrEmpty(actual));
            }
            else
            {
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
