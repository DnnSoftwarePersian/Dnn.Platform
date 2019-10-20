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
using System.Collections;
using System.Collections.Generic;

namespace DotNetNuke.Services.Log.EventLog
{
    public interface ILogController
    {
        void AddLog(LogInfo logInfo);

        void AddLogType(string configFile, string fallbackConfigFile);

        void AddLogType(LogTypeInfo logType);

        void AddLogTypeConfigInfo(LogTypeConfigInfo logTypeConfig);

        void ClearLog();

        void DeleteLog(LogInfo logInfo);

        void DeleteLogType(LogTypeInfo logType);

        void DeleteLogTypeConfigInfo(LogTypeConfigInfo logTypeConfig);

        List<LogInfo> GetLogs(int portalID, string logType, int pageSize, int pageIndex, ref int totalRecords);

        ArrayList GetLogTypeConfigInfo();

        LogTypeConfigInfo GetLogTypeConfigInfoByID(string id);

        Dictionary<string, LogTypeInfo> GetLogTypeInfoDictionary();

        object GetSingleLog(LogInfo log, LoggingProvider.ReturnType returnType);

        void PurgeLogBuffer();

        void UpdateLogTypeConfigInfo(LogTypeConfigInfo logTypeConfig);

        void UpdateLogType(LogTypeInfo logType);
    }
}
