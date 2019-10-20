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

#endregion

namespace DotNetNuke.ComponentModel
{
    public abstract class ComponentBase<TContract, TType> where TType : class, TContract
    {
        private static TContract _testableInstance;
        private static bool _useTestable = false;

        public static TContract Instance
        {
            get
            {
                if (_useTestable && _testableInstance != null)
                    return _testableInstance;

                var component = ComponentFactory.GetComponent<TContract>();

                if (component == null)
                {
                    component = (TContract) Activator.CreateInstance(typeof (TType), true);
                    ComponentFactory.RegisterComponentInstance<TContract>(component);
                }

                return component;
            }
        }

        /// <summary>
        /// Registers an instance to use for the Singleton
        /// </summary>
        /// <remarks>Intended for unit testing purposes, not thread safe</remarks>
        /// <param name="instance"></param>
        internal static void SetTestableInstance(TContract instance)
        {
            _testableInstance = instance;
            _useTestable = true;
        }

        /// <summary>
        /// Clears the current instance, a new instance will be initialized when next requested
        /// </summary>
        /// <remarks>Intended for unit testing purposes, not thread safe</remarks>
        internal static void ClearInstance()
        {
            _useTestable = false;
            _testableInstance = default(TContract);
        }

        public static void RegisterInstance(TContract instance)
        {
            if ((ComponentFactory.GetComponent<TContract>() == null))
            {
                ComponentFactory.RegisterComponentInstance<TContract>(instance);
            }
        }
    }
}
