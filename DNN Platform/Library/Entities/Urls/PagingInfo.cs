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
    /// Class used as a utility to help manage paging in database queries
    /// </summary>
    public class PagingInfo
    {
        public PagingInfo(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }

        public int FirstRow { get; private set; }

        public int LastRow { get; private set; }

        public int TotalRows { get; private set; }

        public int TotalPages { get; private set; }

        public bool IsLastPage
        {
            get
            {
                if (LastRow >= (TotalRows))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void UpdatePageResults(int firstRow, int lastRow, int totalRows, int totalPages)
        {
            FirstRow = firstRow;
            LastRow = lastRow;
            TotalRows = totalRows;
            TotalPages = totalPages;
        }
    }
}
