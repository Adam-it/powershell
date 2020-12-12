﻿using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using System;
using PnP.PowerShell.Commands.Enums;

namespace PnP.PowerShell.Commands.Branding
{
    [Cmdlet(VerbsCommon.Get, "PnPCustomAction")]
    public class GetCustomAction : PnPWebRetrievalsCmdlet<UserCustomAction>
    {
        [Parameter(Mandatory = false)]
        public Guid Identity;

        [Parameter(Mandatory = false)]
        public CustomActionScope Scope = CustomActionScope.Web;

        [Parameter(Mandatory = false)]
        public SwitchParameter ThrowExceptionIfCustomActionNotFound;

        protected override void ExecuteCmdlet()
        {
            List<UserCustomAction> actions = new List<UserCustomAction>();

            if (Scope == CustomActionScope.All || Scope == CustomActionScope.Web)
            {
                actions.AddRange(SelectedWeb.GetCustomActions(RetrievalExpressions));
            }
            if (Scope == CustomActionScope.All || Scope == CustomActionScope.Site)
            {
                actions.AddRange(ClientContext.Site.GetCustomActions(RetrievalExpressions));
            }

            if (Identity != null)
            {
                var foundAction = actions.FirstOrDefault(x => x.Id == Identity);
                if (foundAction != null || !ThrowExceptionIfCustomActionNotFound)
                {
                    WriteObject(foundAction, true);
                }
                else
                {
                    throw new PSArgumentException($"No CustomAction found with the Identity '{Identity}' within the scope '{Scope}'", "Identity");
                }
            }
            else
            {
                WriteObject(actions, true);
            }
        }
    }
}