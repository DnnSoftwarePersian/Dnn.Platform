﻿// 
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
using System.Data;

#endregion

namespace DotNetNuke.Entities.Users.Social.Data
{
    public interface IDataService
    {
        #region RelationshipType CRUD

        void DeleteRelationshipType(int relationshipTypeId);
        IDataReader GetAllRelationshipTypes();
        IDataReader GetRelationshipType(int relationshipTypeId);
        int SaveRelationshipType(RelationshipType relationshipType, int createUpdateUserId);

        #endregion

        #region Relationship CRUD

        void DeleteRelationship(int relationshipId);
        IDataReader GetRelationship(int relationshipId);
        IDataReader GetRelationshipsByUserId(int userId);
        IDataReader GetRelationshipsByPortalId(int portalId);
        int SaveRelationship(Relationship relationship, int createUpdateUserId);

        #endregion

        #region UserRelationship CRUD

        void DeleteUserRelationship(int userRelationshipId);
        IDataReader GetUserRelationship(int userRelationshipId);
        IDataReader GetUserRelationship(int userId, int relatedUserId, int relationshipId, RelationshipDirection relationshipDirection);
        IDataReader GetUserRelationships(int userId);
        IDataReader GetUserRelationshipsByRelationshipId(int relationshipId);
        int SaveUserRelationship(UserRelationship userRelationship, int createUpdateUserId);

        #endregion

        #region UserRelationshipPreference CRUD

        void DeleteUserRelationshipPreference(int preferenceId);
        IDataReader GetUserRelationshipPreferenceById(int preferenceId);
        IDataReader GetUserRelationshipPreference(int userId, int relationshipId);
        int SaveUserRelationshipPreference(UserRelationshipPreference userRelationshipPreference, int createUpdateUserId);

        #endregion
    }
}
