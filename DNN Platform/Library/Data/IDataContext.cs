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
using System;
using System.Collections.Generic;
using System.Data;

namespace DotNetNuke.Data
{
    public interface IDataContext : IDisposable
    {
        void BeginTransaction();
        void Commit();

        void Execute(CommandType type, string sql, params object[] args);
        IEnumerable<T> ExecuteQuery<T>(CommandType type, string sql, params object[] args);
        T ExecuteScalar<T>(CommandType type, string sql, params object[] args);
        T ExecuteSingleOrDefault<T>(CommandType type, string sql, params object[] args);

        IRepository<T> GetRepository<T>() where T : class;
        void RollbackTransaction();
    }
}
