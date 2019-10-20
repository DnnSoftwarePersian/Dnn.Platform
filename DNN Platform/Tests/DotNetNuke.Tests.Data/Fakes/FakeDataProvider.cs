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
using System.Collections.Generic;
using System.Data;

using DotNetNuke.Data;

namespace DotNetNuke.Tests.Data.Fakes
{
    internal class FakeDataProvider : DataProvider
    {
        public FakeDataProvider(Dictionary<string, string> settings )
        {
            Settings = settings;
        }

        #region Overrides of DataProvider

        public override bool IsConnectionValid
        {
            get { throw new System.NotImplementedException(); }
        }

        public override Dictionary<string, string> Settings { get; }

        public override void ExecuteNonQuery(string procedureName, params object[] commandParameters)
        {
            throw new System.NotImplementedException();
        }

        public override void ExecuteNonQuery(int timeoutSec, string procedureName, params object[] commandParameters)
        {
            throw new System.NotImplementedException();
        }

        public override void BulkInsert(string procedureName, string tableParameterName, DataTable dataTable)
        {
            throw new System.NotImplementedException();
        }

        public override void BulkInsert(string procedureName, string tableParameterName, DataTable dataTable, int timeoutSec)
        {
            throw new System.NotImplementedException();
        }

        public override void BulkInsert(string procedureName, string tableParameterName, DataTable dataTable, Dictionary<string, object> commandParameters)
        {
            throw new System.NotImplementedException();
        }

        public override void BulkInsert(string procedureName, string tableParameterName, DataTable dataTable, int timeoutSec,
            Dictionary<string, object> commandParameters)
        {
            throw new System.NotImplementedException();
        }

        public override IDataReader ExecuteReader(string procedureName, params object[] commandParameters)
        {
            throw new System.NotImplementedException();
        }

        public override IDataReader ExecuteReader(int timeoutSec, string procedureName, params object[] commandParameters)
        {
            throw new System.NotImplementedException();
        }

        public override T ExecuteScalar<T>(string procedureName, params object[] commandParameters)
        {
            throw new System.NotImplementedException();
        }

        public override T ExecuteScalar<T>(int timeoutSec, string procedureName, params object[] commandParameters)
        {
            throw new System.NotImplementedException();
        }

        public override IDataReader ExecuteSQL(string sql)
        {
            throw new System.NotImplementedException();
        }

        public override IDataReader ExecuteSQL(string sql, int timeoutSec)
        {
            throw new System.NotImplementedException();
        }

        public override string ExecuteScript(string script)
        {
            throw new System.NotImplementedException();
        }

        public override string ExecuteScript(string script, int timeoutSec)
        {
            throw new System.NotImplementedException();
        }

        public override string ExecuteScript(string connectionString, string sql)
        {
            throw new System.NotImplementedException();
        }

        public override string ExecuteScript(string connectionString, string sql, int timeoutSec)
        {
            throw new System.NotImplementedException();
        }

        public override IDataReader ExecuteSQLTemp(string connectionString, string sql)
        {
            throw new System.NotImplementedException();
        }

        public override IDataReader ExecuteSQLTemp(string connectionString, string sql, int timeoutSec)
        {
            throw new System.NotImplementedException();
        }

        public override IDataReader ExecuteSQLTemp(string connectionString, string sql, out string errorMessage)
        {
            throw new System.NotImplementedException();
        }

        public override IDataReader ExecuteSQLTemp(string connectionString, string sql, int timeoutSec, out string errorMessage)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
