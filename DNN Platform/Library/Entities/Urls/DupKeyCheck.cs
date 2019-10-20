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
namespace DotNetNuke.Entities.Urls
{
    /// <summary>
    /// The DupKeyCheck class is a small helper class used to maintain state of what to do with a duplicate Url when building the Url Index.
    /// </summary>
    internal class DupKeyCheck
    {
        public DupKeyCheck(string tabKey, string tabIdOriginal, string tabPath, bool isDeleted)
        {
            TabKey = tabKey;
            TabIdOriginal = tabIdOriginal;
            TabPath = tabPath;
            IsDeleted = isDeleted;
        }

        public string TabKey { get; set; }
        public string TabIdOriginal { get; set; }
        public string TabPath { get; set; }
        public bool IsDeleted { get; set; }
    }
}
