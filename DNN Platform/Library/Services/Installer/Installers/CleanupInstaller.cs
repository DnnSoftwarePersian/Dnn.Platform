// 
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
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Instrumentation;
using Microsoft.Extensions.FileSystemGlobbing;

#endregion

namespace DotNetNuke.Services.Installer.Installers
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The CleanupInstaller cleans up (removes) files from previous versions
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// -----------------------------------------------------------------------------
    public class CleanupInstaller : FileInstaller
    {
    	private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof (CleanupInstaller));
		#region "Private Members"

        private string _fileName;
        private string _glob;

		#endregion

		#region "Public Properties"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets a list of allowable file extensions (in addition to the Host's List)
        /// </summary>
        /// <value>A String</value>
        /// -----------------------------------------------------------------------------
        public override string AllowableFiles => "*";

        #endregion

	#region "Private Methods"

        private bool ProcessCleanupFile()
        {
            Log.AddInfo(string.Format(Util.CLEANUP_Processing, Version.ToString(3)));
            try
            {
                var strListFile = Path.Combine(Package.InstallerInfo.TempInstallFolder, _fileName);
                if (File.Exists(strListFile))
                {
                    FileSystemUtils.DeleteFiles(File.ReadAllLines(strListFile));
                }
            }
            catch (Exception ex)
            {
                Log.AddWarning(string.Format(Util.CLEANUP_ProcessError, ex.Message));
                //DNN-9202: MUST NOT fail installation when cleanup files deletion fails
                //return false;
            }
            Log.AddInfo(string.Format(Util.CLEANUP_ProcessComplete, Version.ToString(3)));
            return true;
        }

        private bool ProcessGlob()
        {
            Log.AddInfo(string.Format(Util.CLEANUP_Processing, Version.ToString(3)));
            try
            {
                if (_glob.Contains(".."))
                {
                    Log.AddWarning(Util.EXCEPTION + " - " + Util.EXCEPTION_GlobDotDotNotSupportedInCleanup);
                }
                else
                {
                    var globs = new Matcher(StringComparison.InvariantCultureIgnoreCase);
                    globs.AddIncludePatterns(_glob.Split(';'));
                    var files = globs.GetResultsInFullPath(Globals.ApplicationMapPath).ToArray();
                    FileSystemUtils.DeleteFiles(files);
                }
            }
            catch (Exception ex)
            {
                Log.AddWarning(string.Format(Util.CLEANUP_ProcessError, ex.Message));
            }
            Log.AddInfo(string.Format(Util.CLEANUP_ProcessComplete, Version.ToString(3)));
            return true;
        }
		
		#endregion

		#region "Protected Methods"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The CleanupFile method cleansup a single file.
        /// </summary>
        /// <param name="insFile">The InstallFile to clean up</param>
        /// -----------------------------------------------------------------------------
        protected bool CleanupFile(InstallFile insFile)
        {
            try
            {
				//Backup File
                if (File.Exists(PhysicalBasePath + insFile.FullName))
                {
                    Util.BackupFile(insFile, PhysicalBasePath, Log);
                }
				
				//Delete file
                Util.DeleteFile(insFile, PhysicalBasePath, Log);
                return true;
            }
            catch (Exception exc)
            {
                Logger.Error(exc);

                return false;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The ProcessFile method determines what to do with parsed "file" node
        /// </summary>
        /// <param name="file">The file represented by the node</param>
        /// <param name="nav">The XPathNavigator representing the node</param>
        /// -----------------------------------------------------------------------------
        protected override void ProcessFile(InstallFile file, XPathNavigator nav)
        {
            if (file != null)
            {
                Files.Add(file);
            }
        }

        protected override InstallFile ReadManifestItem(XPathNavigator nav, bool checkFileExists)
        {
            return base.ReadManifestItem(nav, false);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The RollbackFile method rolls back the cleanup of a single file.
        /// </summary>
        /// <param name="installFile">The InstallFile to commit</param>
        /// -----------------------------------------------------------------------------
        protected override void RollbackFile(InstallFile installFile)
        {
            if (File.Exists(installFile.BackupFileName))
            {
                Util.RestoreFile(installFile, PhysicalBasePath, Log);
            }
        }
		
		#endregion

		#region "Public Methods"


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The Commit method finalises the Install and commits any pending changes.
        /// </summary>
        /// <remarks>In the case of Clenup this is not neccessary</remarks>
        /// -----------------------------------------------------------------------------
        public override void Commit()
        {
			//Do nothing
            base.Commit();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The Install method cleansup the files
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void Install()
        {
            try
            {
                bool bSuccess = true;
                if (string.IsNullOrEmpty(_fileName) && string.IsNullOrEmpty(_glob)) // No attribute: use the xml files definition.
                {
                    foreach (InstallFile file in Files)
                    {
                        bSuccess = CleanupFile(file);
                        if (!bSuccess)
                        {
                            break;
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(_fileName)) // Cleanup file provided: clean each file in the cleanup text file line one by one.
                {
                    bSuccess = ProcessCleanupFile();
                }
                else if (!string.IsNullOrEmpty(_glob)) // A globbing pattern was provided, use it to find the files and delete what matches.
                {
                    bSuccess = ProcessGlob();
                }
                Completed = bSuccess;
            }
            catch (Exception ex)
            {
                Log.AddFailure(Util.EXCEPTION + " - " + ex.Message);
            }
        }

        public override void ReadManifest(XPathNavigator manifestNav)
        {
            _fileName = Util.ReadAttribute(manifestNav, "fileName");
            _glob = Util.ReadAttribute(manifestNav, "glob");
            base.ReadManifest(manifestNav);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The UnInstall method uninstalls the file component
        /// </summary>
        /// <remarks>There is no uninstall for this component</remarks>
        /// -----------------------------------------------------------------------------
        public override void UnInstall()
        {
        }
		
		#endregion
    }
}
