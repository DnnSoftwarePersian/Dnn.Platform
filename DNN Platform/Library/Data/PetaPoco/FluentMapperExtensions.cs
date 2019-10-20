﻿// 
<<<<<<< HEAD
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
// 
// Influenced by http://sameproblemmorecode.blogspot.nl/2013/07/petapoco-as-its-meant-to-be-with.html
// https://github.com/luuksommers/PetaPoco

using System;
using System.Linq.Expressions;
using System.Web.Caching;
using PetaPoco;

namespace DotNetNuke.Data.PetaPoco
{
    public static class FluentMapperExtensions
    {
        public static FluentMapper<TModel> AddFluentMapper<TModel>(this IDataContext dataContext)
        {
            var petaPocoDataContext = dataContext as PetaPocoDataContext;
            FluentMapper<TModel> mapper = null;

            // ReSharper disable once UseNullPropagation
            if (petaPocoDataContext != null)
            {
                mapper = new FluentMapper<TModel>(petaPocoDataContext.TablePrefix);
                petaPocoDataContext.FluentMappers.Add(typeof(TModel), mapper);
            }

            return mapper;
        }

        public static FluentMapper<TModel> Cache<TModel>(this FluentMapper<TModel> mapper, string cacheKey, int timeOut = 20, CacheItemPriority priority = CacheItemPriority.Default)
        {
            mapper.CacheKey = cacheKey;
            mapper.CacheTimeOut = timeOut;
            mapper.CachePriority = priority;
            return mapper;
        }

        public static FluentMapper<TModel> Property<TModel, TProperty>(this FluentMapper<TModel> mapper, Expression<Func<TModel, TProperty>> action, string column, bool primaryKey = false, bool readOnly = false) where TModel : class
        {
            return mapper.Property(action, column, null, primaryKey, readOnly);
        }

        public static FluentMapper<TModel> Property<TModel, TProperty>(this FluentMapper<TModel> mapper, Expression<Func<TModel, TProperty>> action, string column, Func<object, object> fromDbConverter, bool primaryKey = false, bool readOnly = false) where TModel : class
        {
            return mapper.Property(action, column, fromDbConverter, null, primaryKey, readOnly);
        }

        public static FluentMapper<TModel> Property<TModel, TProperty>(this FluentMapper<TModel> mapper, Expression<Func<TModel, TProperty>> action, string column, Func<object, object> fromDbConverter, Func<object, object> toDbConverter, bool primaryKey = false, bool readOnly = false) where TModel : class
        {
            var expression = (MemberExpression)action.Body;
            string name = expression.Member.Name;

            mapper.Mappings.Add(name, new FluentColumnMap(new ColumnInfo() { ColumnName = column, ResultColumn = readOnly }, fromDbConverter, toDbConverter));

            if (primaryKey)
            {
                if (!string.IsNullOrEmpty(mapper.TableInfo.PrimaryKey))
                    mapper.TableInfo.PrimaryKey += ",";
                mapper.TableInfo.PrimaryKey += column;
            }
            return mapper;
        }

        public static FluentMapper<TModel> PrimaryKey<TModel>(this FluentMapper<TModel> mapper, string primaryKey, bool autoIncrement = true)
        {
            mapper.TableInfo.PrimaryKey = primaryKey;
            mapper.TableInfo.AutoIncrement = autoIncrement;

            return mapper;
        }

        public static FluentMapper<TModel> Scope<TModel>(this FluentMapper<TModel> mapper, string scope)
        {
            mapper.Scope = scope;
            return mapper;
        }

        public static FluentMapper<TModel> TableName<TModel>(this FluentMapper<TModel> mapper, string tableName)
        {
            mapper.TableInfo.TableName = mapper.GetTablePrefix() + tableName;

            return mapper;
        }
    }
}
