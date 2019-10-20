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

#endregion

namespace DotNetNuke.Entities.Urls
{
    [Serializable]
    public class PathSizes
    {
        public int MaxAliasDepth { get; set; }
        public int MaxTabPathDepth{ get; set; }
        public int MinAliasDepth { get; set; }
        public int MinTabPathDepth { get; set; }

        public void SetAliasDepth(string httpAlias)
        {
            int aliasPathDepth = httpAlias.Length - httpAlias.Replace("/", "").Length;
            if (aliasPathDepth > MaxAliasDepth)
            {
                MaxAliasDepth = aliasPathDepth;
            }
            if (aliasPathDepth < MinAliasDepth)
            {
                MinAliasDepth = aliasPathDepth;
            }
        }

        public void SetTabPathDepth(int tabPathDepth)
        {
            if (tabPathDepth > MaxTabPathDepth)
            {
                MaxTabPathDepth = tabPathDepth;
            }
            if (tabPathDepth < MinTabPathDepth)
            {
                MinTabPathDepth = tabPathDepth;
            }
        }
    }
}
