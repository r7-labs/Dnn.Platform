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
#region Usings

using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Security;
using DotNetNuke.Services.Localization;
using DotNetNuke.Web.Razor;
using System;

#endregion

namespace DotNetNuke.Modules.RazorHost
{
    [Obsolete("Deprecated in 9.3.2, will be removed in 11.0.0, use Razor Pages instead")]
    public partial class RazorHost : RazorModuleBase, IActionable
    {
        private string razorScriptFileFormatString = "~/DesktopModules/RazorModules/RazorHost/Scripts/{0}";

        [Obsolete("Deprecated in 9.3.2, will be removed in 11.0.0, use Razor Pages instead")]
        protected override string RazorScriptFile
        {
            get
            {
                string m_RazorScriptFile = base.RazorScriptFile;
                var scriptFileSetting = ModuleContext.Settings["ScriptFile"] as string;
                if (! (string.IsNullOrEmpty(scriptFileSetting)))
                {
                    m_RazorScriptFile = string.Format(razorScriptFileFormatString, scriptFileSetting);
                }
                return m_RazorScriptFile;
            }
        }

        #region IActionable Members

        [Obsolete("Deprecated in 9.3.2, will be removed in 11.0.0, use Razor Pages instead")]
        public ModuleActionCollection ModuleActions
        {
            get
            {
                var Actions = new ModuleActionCollection();
                Actions.Add(ModuleContext.GetNextActionID(),
                            Localization.GetString(ModuleActionType.EditContent, LocalResourceFile),
                            ModuleActionType.AddContent,
                            "",
                            "edit.gif",
                            ModuleContext.EditUrl(),
                            false,
                            SecurityAccessLevel.Host,
                            true,
                            false);
                Actions.Add(ModuleContext.GetNextActionID(),
                            Localization.GetString("CreateModule.Action", LocalResourceFile),
                            ModuleActionType.AddContent,
                            "",
                            "edit.gif",
                            ModuleContext.EditUrl("CreateModule"),
                            false,
                            SecurityAccessLevel.Host,
                            true,
                            false);
                return Actions;
            }
        }

        #endregion
    }
}