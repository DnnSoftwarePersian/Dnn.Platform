<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
﻿using Microsoft.WindowsAzure.Storage.Blob;
=======
﻿﻿#region Copyright
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
// All Rights Reserved
#endregion

using Microsoft.WindowsAzure.Storage.Blob;
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)

namespace DotNetNuke.Providers.FolderProviders.AzureFolderProvider
{
    internal static class BlobItemExtensions
    {
        public static string RelativePath(this IListBlobItem item)
        {
            var filterUrl = item.Container.Uri.AbsoluteUri;
            if (!filterUrl.EndsWith("/"))
            {
                filterUrl = filterUrl + "/";
            }

            return item.Uri.AbsoluteUri.Replace(filterUrl, string.Empty);
        }
    }
}
