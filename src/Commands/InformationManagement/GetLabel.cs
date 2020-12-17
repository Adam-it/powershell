﻿using System.Management.Automation;
using Microsoft.SharePoint.Client;

using PnP.PowerShell.Commands.Base.PipeBinds;

namespace PnP.PowerShell.Commands.InformationManagement
{
    [Cmdlet(VerbsCommon.Get, "PnPLabel")]
    
    

    public class GetLabel : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public ListPipeBind List;

        [Parameter(Mandatory = false)]
        public SwitchParameter ValuesOnly;

        protected override void ExecuteCmdlet()
        {
            var list = List.GetList(CurrentWeb);
            if (list != null)
            {
                var listUrl = list.RootFolder.ServerRelativeUrl;
                var label = Microsoft.SharePoint.Client.CompliancePolicy.SPPolicyStoreProxy.GetListComplianceTag(ClientContext, listUrl);
                ClientContext.ExecuteQueryRetry();

                if (label.Value == null)
                {
                    WriteWarning("No label found for the specified library.");
                }
                else
                {
                    if (ParameterSpecified(nameof(ValuesOnly)))
                    {
                        WriteObject(label.Value);
                    }
                    else
                    {
                        WriteObject("The label '" + label.Value.TagName + "' is set to the specified list or library. ");
                        // There is no property yet that exposes if the SyncToItems is set or not.. :(
                        WriteObject("Block deletion: " + label.Value.BlockDelete.ToString());
                        WriteObject("Block editing: " + label.Value.BlockEdit.ToString());
                    }
                }
            }
            else
            {
                WriteWarning("List or library not found.");
            }
        }
    }
}