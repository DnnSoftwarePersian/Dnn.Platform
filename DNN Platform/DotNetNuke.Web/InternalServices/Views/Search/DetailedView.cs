// 
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
#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace DotNetNuke.Web.InternalServices.Views.Search
{
    /// <summary>
    /// Detailed Search Result View
    /// </summary>
    public class DetailedView : BasicView
    {
        /// <summary>
        /// Tags associated with Document
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
        
        /// <summary>
        /// Time when Content was last modified (in Utc)
        /// </summary>
        public String DisplayModifiedTime { get; set; }

        /// <summary>
        /// Author profile URL
        /// </summary>
        public string AuthorProfileUrl { get; set; }

        /// <summary>
        /// Optional: Display Name of the Author
        /// </summary>
        /// <remarks>This may be different form current Display Name when Index was run prior to change in Display Name.</remarks>
        public string AuthorName { get; set; }

        /// <summary>
        /// Number of Likes associated with Content.
        /// </summary>
        /// <remarks>Content with more Likes is ranked higher.</remarks>
        public int Likes { get; set; }

        /// <summary>
        /// Number of Comments associated with Content.
        /// </summary>
        /// <remarks>Content with more Comments is ranked higher.</remarks>
        public int Comments { get; set; }

        /// <summary>
        /// Number of Views associated with Content.
        /// </summary>
        /// <remarks>Content with more Views is ranked higher.</remarks>
        public int Views { get; set; }
        
    }
}
