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

using DotNetNuke.Collections;
using DotNetNuke.Data;

namespace DotNetNuke.Tests.Data.Fakes
{
    public class FakeRepository<T> : RepositoryBase<T> where T : class
    {
        public override void Delete(string sqlCondition, params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<T> Find(string sqlCondition, params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public override IPagedList<T> Find(int pageIndex, int pageSize, string sqlCondition, params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(string sqlCondition, params object[] args)
        {
            throw new System.NotImplementedException();
        }

        protected override IPagedList<T> GetPageByScopeInternal(object propertyValue, int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        protected override T GetByIdInternal(object id)
        {
            throw new System.NotImplementedException();
        }

        protected override void InsertInternal(T item)
        {
            throw new System.NotImplementedException();
        }

        protected override void DeleteInternal(T item)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<T> GetInternal()
        {
            throw new System.NotImplementedException();
        }

        protected override IPagedList<T> GetPageInternal(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<T> GetByScopeInternal(object propertyValue)
        {
            throw new System.NotImplementedException();
        }

        protected override void UpdateInternal(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
