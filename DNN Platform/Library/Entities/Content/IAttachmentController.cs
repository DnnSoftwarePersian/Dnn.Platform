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
using DotNetNuke.Services.FileSystem;

namespace DotNetNuke.Entities.Content
{
    /// <summary>Interface of FileController</summary>
    /// <seealso cref="AttachmentController"/>
    public interface IAttachmentController
    {
        /// <summary>
        /// Add a generic file to a <see cref="ContentItem"/>.
        /// </summary>
        /// <param name="contentItemId">The content item</param>
        /// <param name="fileInfo">A file registered in the DotNetNuke <seealso cref="FileManager"/></param>
        void AddFileToContent(int contentItemId, IFileInfo fileInfo);

        void AddFilesToContent(int contentItemId, IEnumerable<IFileInfo> fileInfo);

        /// <summary>
        /// Add a video file to a <see cref="ContentItem"/>.
        /// </summary>
        /// <param name="contentItemId">The content item</param>
        /// <param name="fileInfo">A file registered in the DotNetNuke <seealso cref="FileManager"/></param>
        void AddVideoToContent(int contentItemId, IFileInfo fileInfo);

        void AddVideosToContent(int contentItemId, IEnumerable<IFileInfo> fileInfo);

        /// <summary>
        /// Attach an image to a ContentItem.
        /// </summary>
        /// <param name="contentItemId">The content item</param>
        /// <param name="fileInfo">A file registered in the DotNetNuke <seealso cref="FileManager"/></param>
        void AddImageToContent(int contentItemId, IFileInfo fileInfo);

        void AddImagesToContent(int contentItemId, IEnumerable<IFileInfo> fileInfo);

        IList<IFileInfo> GetFilesByContent(int contentItemId);

        IList<IFileInfo> GetVideosByContent(int contentItemId);
        
        IList<IFileInfo> GetImagesByContent(int contentItemId);
    }
}
