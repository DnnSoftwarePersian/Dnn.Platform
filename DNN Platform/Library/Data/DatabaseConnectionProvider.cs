﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
<<<<<<< HEAD
=======
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2014
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
#region usings

using System.Collections.Generic;
using System.Data;

using DotNetNuke.ComponentModel;

#endregion

namespace DotNetNuke.Data
{
    public abstract class DatabaseConnectionProvider
    {
        #region Shared/Static Methods

        public static DatabaseConnectionProvider Instance()
        {
            return ComponentFactory.GetComponent<DatabaseConnectionProvider>();
        }

        #endregion

        #region Public Methods

        public abstract int ExecuteNonQuery(string connectionString, CommandType commandType, int commandTimeout, string query);

        public abstract void ExecuteNonQuery(string connectionString, CommandType commandType, int commandTimeout, string procedure, object[] commandParameters);

        public abstract IDataReader ExecuteSql(string connectionString, CommandType commandType, int commandTimeout, string query);

        public abstract IDataReader ExecuteReader(string connectionString, CommandType commandType, int commandTimeout, string procedureName, params object[] commandParameters);

        public abstract T ExecuteScalar<T>(string connectionString, CommandType commandType, int commandTimeout, string procedureName, params object[] commandParameters);

        public abstract void BulkInsert(string connectionString, int commandTimeout, string procedureName, string tableParameterName, DataTable dataTable);

        public abstract void BulkInsert(string connectionString, int commandTimeout, string procedureName, string tableParameterName, DataTable dataTable, Dictionary<string, object> commandParameters);

        #endregion
    }
}
