﻿
using PnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Linq;
using System.Management.Automation;

namespace PnP.PowerShell.Commands.ClientSidePages
{
    [Cmdlet(VerbsCommon.Get, "PnPClientSideComponent")]
    public class GetClientSideControl : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)]
        public ClientSidePagePipeBind Page;

        [Parameter(Mandatory = false, ValueFromPipeline = true)]
        public Guid InstanceId;

        protected override void ExecuteCmdlet()
        {
            var clientSidePage = Page.GetPage();

            if (clientSidePage == null)
                throw new Exception($"Page '{Page?.Name}' does not exist");

            if(!ParameterSpecified(nameof(InstanceId)))
            {
                WriteObject(clientSidePage.Controls, true);
            } else
            {
                WriteObject(clientSidePage.Controls.FirstOrDefault(c => c.InstanceId == InstanceId));
            }

        }
    }
}