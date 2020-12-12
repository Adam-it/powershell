﻿using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using PnP.PowerShell.Commands.Base.PipeBinds;
using PnP.Framework.ALM;
using System;
using PnP.PowerShell.Commands.Enums;
using PnP.Framework.Enums;
using Microsoft.SharePoint.Client;

namespace PnP.PowerShell.Commands.Apps
{
    [Cmdlet(VerbsCommon.Get, "PnPApp")]
    public class GetApp : PnPSharePointCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
        public AppMetadataPipeBind Identity;

        [Parameter(Mandatory = false)]
        public AppCatalogScope Scope = AppCatalogScope.Tenant;

        protected override void ExecuteCmdlet()
        {
            var manager = new AppManager(ClientContext);

            if (ParameterSpecified(nameof(Identity)))
            {
                var app = Identity.GetAppMetadata(ClientContext, Scope);
                if (app != null)
                {
                    WriteObject(app);
                } else
                {
                    throw new Exception("Cannot find app");
                }
            }
            else
            {
                var apps = manager.GetAvailable(Scope);
                WriteObject(apps,true);
            }
        }
    }
}