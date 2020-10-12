﻿using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using PnP.PowerShell.Commands.Base;
using System.Management.Automation;
using PnP.PowerShell.Commands.Base.PipeBinds;

namespace PnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Remove, "SiteUserInvitations")]
    public class RemoveSiteUserInvitations : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false)]
        public SitePipeBind Site;

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string EmailAddress;

        [Parameter(Mandatory = false)]
        public SwitchParameter CountOnly;

        protected override void ExecuteCmdlet()
        {
            var url = PnPConnection.CurrentConnection.Url;
            if (ParameterSpecified(nameof(Site)))
            {
                url = Site.Url;
            }
            var invitations = Tenant.RemoveSPOTenantSiteUserInvitations(url, EmailAddress, CountOnly);
            ClientContext.ExecuteQueryRetry();
            WriteObject(invitations, true);
        }
    }
}