# Building Dnn

You do not always need to build the entire solution, you can download and install from the releases and only build the part you are working on, please read [How to Contribue](CONTRIBUTING.md) first.

<<<<<<< HEAD
<<<<<<< HEAD
There are three supported build scenarios:
1. **Build to create a platform distribution package**. You'd only use this to test a complete package (how it installs, works, etc). This build process is used by our Continuous Integration system and creates the release packages everyone uses to install the platform.
2. **Build to create a local DNN development website**. You'd typically not do this all the time, but only when you wish to set up a new development site or revert your development website to the current DNN repository state.
3. **Debug build**. You'd use this when changing code and testing your changes on your (previously created) development site. Note you can also "rebuild" just a part of the platform and not the entire solution for this which will speed things up for you.

When contributing to DNN, you'd typically go through steps 2 and 3 at least and maybe 1 if you wish to run more encompassing tests. But before you delve into code, please familiarize yourself with [How to Contribute](CONTRIBUTING.md) first.

## External sources

There are two projects not included in this repository that are distributed with DNN:
=======
If you do need to build the entire solution and the distribution packages, you need to be aware that the entire distribution is split in multiple github repositories.
* This repository - contains all the core APIs and the Admin Experience (Persona Bar)
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
=======
If you do need to build the entire solution and the distribution packages, you need to be aware that the entire distribution is split in multiple github repositories.
* This repository - contains all the core APIs and the Admin Experience (Persona Bar)
>>>>>>> update form orginal repo
* [CKEditorProvider](https://github.com/DNN-Connect/CKEditorProvider) - The default HTML Editor Provider
* [CDF](https://github.com/dnnsoftware/ClientDependency) - The Dnn Client Dependency Framework

Also, we currently maintain two branches, the development branch is the next major release and we also maintain a release/x.x.x branch that allows doing bug fixes on the current major version.

To prevent issues with long paths in some build scripts, fork this repository in a short named folder on the root of any drive such as `c:\dnnsrc\` if you fork to a long path such as `c:\users\username\documents\dnn\source\` you may encounter long path issues.

<<<<<<< HEAD
<<<<<<< HEAD
=======
In order to build the whole solution and produce the install and upgrade packages, you simply need to open PowerShell and run the following command:
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
=======
In order to build the whole solution and produce the install and upgrade packages, you simply need to open PowerShell and run the following command:
>>>>>>> update form orginal repo
```
.\build.ps1
```

<<<<<<< HEAD
<<<<<<< HEAD
This will trigger the build and packaging logic. The packages are created in the `artifacts` folder. 

Note that (unless a build version has been specified, see below) this process will retrieve the latest version from Github and use that to version dlls and manifests. This creates a bunch of changed `.dnn` files and you'll need to make sure you don't include those in any Pull Requests when contributing.

## Build to create/update your development site

This process also uses Cake and follows the same logic as above, with the sole difference that the output is not a distribution zip file but rather this process pumps contents out to a directory you specify. Also you need to tell this process about your SQL server so that it can reset the database. When complete you should get the same experience as if you've built the platform and unpacked it on a server.

### Prerequisites

You'll need to be running IIS and SQL server (Express) locally for this to work. Create a folder on your hard disk and set it up in IIS as a web application. Then create or edit the local settings file.

### Local Settings file

The build process uses a local settings file which is excluded from source control so you won't accidentally upload this to Github. First open up Powershell at the root of this repository and run the following:

```
.\Build.ps1 -Target CreateSettings
=======
The version you are building is the current version on the branch you are. However there are 2 external repositories that get bundled into Dnn build:
[Dnn.Connect CKEditor provider](https://github.com/DNN-Connect/CKEditorProvider) is the default HTML editor provider and its default branch is development.	
[Dnn.ClientDependency](https://github.com/dnnsoftware/ClientDependency), the default branch is dnn
Under normal situations they are the branches used for the next release, however if you have a need to specify a different branch to pull during the build you can specify them as such:
```
.\build.ps1 -ScriptArgs '--CkBranch="branch-name"','--CdfBranch="branch-name"'
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
=======
The version you are building is the current version on the branch you are. However there are 2 external repositories that get bundled into Dnn build:
[Dnn.Connect CKEditor provider](https://github.com/DNN-Connect/CKEditorProvider) is the default HTML editor provider and its default branch is development.	
[Dnn.ClientDependency](https://github.com/dnnsoftware/ClientDependency), the default branch is dnn
Under normal situations they are the branches used for the next release, however if you have a need to specify a different branch to pull during the build you can specify them as such:
```
.\build.ps1 -ScriptArgs '--CkBranch="branch-name"','--CdfBranch="branch-name"'
>>>>>>> update form orginal repo
```

If you encounter any build issues, please re-run the build with more verbosity as such:
```
.\build.ps1 -Verbosity diagnostic
```
<<<<<<< HEAD
<<<<<<< HEAD

This will attempt to delete all content in `WebsitePath` and will build DNN to that location.

## Build Debug

Note: **you need to have gone through the steps for setting up a dev site (see above) for this to work.**

To build the .net projects to the right location, you'll need to create your override of the core build variables in the `DNN_Platform.local.build` file:

``` xml
<Project ToolsVersion="4.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <WebsitePath Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">C:\Path\to\my\DNN\DevSite</WebsitePath>
  </PropertyGroup>
</Project>
=======
.\build.ps1 -Verbosity diagnostic
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
```

<<<<<<< HEAD
Once you've created this file every time you click "rebuild" in Visual Studio on a project (or the solution) you'll see the content change in your dev site.

For the Webpack projects it is set up to read from the `settings.local.json` file and use the `WebsitePath` to copy generated js files to their right place.

## Tips and tricks

### Long paths

To prevent issues with long paths in some build scripts, fork this repository in a short named folder on the root of any drive such as `c:\dnnsrc\` if you fork to a long path such as `c:\users\username\documents\dnn\source\` you may encounter long path issues.

### Tracked files

The build scripts should leave you with 0 tracked modified files in git.
If a build fails midway and you have tracked artifacts, you can simply run:
`git reset --hard` and/or `git clean -dxf` in order to come back to a clean state.

### Running Cake

If you encounter PowerShell security issues, please read [Cake - PowerShell Security](https://cakebuild.net/docs/tutorials/powershell-security)

### Git branching strategy

Our default branch is called **develop**, this is the branch most pull requests should target in order to be merged into the very next release (bug fixes, minor improvements that are not breaking changes). If you know your change will be a breaking change or more risky, then you should submit it targeting the **future/xx** branch (where xx is the next major release). **release/x.x.x** branches are temporary, they get created at code-freeze to built an alpha release for the testing team, when initial testing is done, we publish one or more release candiate versions (RC1, RC2) as needed until we find the version stable for release, at which point we release that new version and close the release/x.x.x branch. The only pull requests that will be accepted for release/x.x.x branches are for regression issues (the problem was introduced in this very version) or showstopper issues (can't use Dnn with this bug in).
=======
Also, the build scripts should leave you with 0 tracked modified files in git.
If a build fails midway and you have tracked artifacts, you can simply run:
`git reset --hard` and/or `git clean -dxf` in order to come back to a clean state.

If you encounter PowerShell security issues, please read [Cake - PowerShell Security](https://cakebuild.net/docs/tutorials/powershell-security)
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
=======
This will log much more information about the problem and allow you to open an issue with those more detailed logs.

Also, the build scripts should leave you with 0 tracked modified files in git.
If a build fails midway and you have tracked artifacts, you can simply run:
`git reset --hard` and/or `git clean -dxf` in order to come back to a clean state.

If you encounter PowerShell security issues, please read [Cake - PowerShell Security](https://cakebuild.net/docs/tutorials/powershell-security)
>>>>>>> update form orginal repo
