<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
#region Copyright

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
using System.Collections.Generic;

#endregion

namespace DotNetNuke.Services.Authentication.OAuth
{
    /// <summary>
    /// Comparer class used to perform the sorting of the query parameters
    /// </summary>
    internal class QueryParameterComparer : IComparer<QueryParameter>
    {
        #region IComparer<QueryParameter> Members

        public int Compare(QueryParameter x, QueryParameter y)
        {
            if (x.Name == y.Name)
            {
                return String.CompareOrdinal(x.Value, y.Value);
            }
            return String.CompareOrdinal(x.Name, y.Name);
        }

        #endregion
    }
}
