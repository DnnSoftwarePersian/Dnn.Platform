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
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;

#endregion

namespace DotNetNuke.Entities.Tabs
{
    ///<summary>
    ///Class to represent a TabAliasSkinInfo object
    ///</summary>
    [Serializable]
    public class TabAliasSkinInfo : BaseEntityInfo, IHydratable
    {
        #region Public Properties

        public int TabAliasSkinId { get; set; }
        public string HttpAlias { get; set; }
        public int PortalAliasId { get; set; }
        public string SkinSrc { get; set; }
        public int TabId { get; set; }

        #endregion

        public int KeyID 
        { 
            get { return TabAliasSkinId; } 
            set { TabAliasSkinId = value; }
        }

        public void Fill(IDataReader dr)
        {
            base.FillInternal(dr);

            TabAliasSkinId = Null.SetNullInteger(dr["TabAliasSkinId"]);
            HttpAlias = Null.SetNullString(dr["HttpAlias"]);
            PortalAliasId = Null.SetNullInteger(dr["PortalAliasId"]);
            SkinSrc = Null.SetNullString(dr["SkinSrc"]);
            TabId = Null.SetNullInteger(dr["TabId"]);
        }
    }
}
