<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿#region Copyright
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
using System.Collections.Generic;

namespace DotNetNuke.Entities.Content.Common
{
    internal class ContentItemEqualityComparer : IEqualityComparer<ContentItem>
    {
        #region Implementation of IEqualityComparer<ContentItem>

        public bool Equals(ContentItem x, ContentItem y)
        {
            return x.ContentItemId == y.ContentItemId;
        }

        public int GetHashCode(ContentItem obj)
        {
            return obj.ContentItemId.GetHashCode();
        }

        #endregion
    }
}
