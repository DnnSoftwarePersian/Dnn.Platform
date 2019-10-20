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
using System.Linq;
using DotNetNuke.Services.Localization;

namespace DotNetNuke.Web.UI.WebControls
{
    public class DnnFormEnumItem : DnnFormComboBoxItem
    {
        private string _enumType;

        public string EnumType
        {
            get
            {
                return _enumType;
            }
            set
            {
                _enumType = value;
                // ReSharper disable AssignNullToNotNullAttribute
                ListSource = (from object enumValue in Enum.GetValues(Type.GetType(_enumType))
                              select new { Name = Localization.GetString(Enum.GetName(Type.GetType(_enumType), enumValue)) ?? Enum.GetName(Type.GetType(_enumType), enumValue), Value = (int)enumValue })
                                .ToList();
                // ReSharper restore AssignNullToNotNullAttribute
            }
        }

        protected override void BindList()
        {
            ListTextField = "Name";
            ListValueField = "Value";

            BindListInternal(ComboBox, Convert.ToInt32(Value), ListSource, ListTextField, ListValueField);
        }
    }
}
