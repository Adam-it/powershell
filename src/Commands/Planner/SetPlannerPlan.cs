using System.Management.Automation;
using PnP.PowerShell.Commands.Attributes;
using PnP.PowerShell.Commands.Base;
using PnP.PowerShell.Commands.Base.PipeBinds;
using PnP.PowerShell.Commands.Utilities;

namespace PnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Set, "PlannerPlan")]
    [MicrosoftGraphApiPermissionCheck(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    [PnPManagementShellScopes("Group.ReadWrite.All")]
    public class SetPlannerPlan : PnPGraphCmdlet
    {
        private const string ParameterName_BYGROUP = "By Group";
        private const string ParameterName_BYPLANID = "By Plan Id";

        [Parameter(Mandatory = true, HelpMessage = "Specify the group id of group owning the plan.", ParameterSetName = ParameterName_BYGROUP)]
        public PlannerGroupPipeBind Group;

        [Parameter(Mandatory = true, HelpMessage = "Specify the id or name of the plan to update.", ParameterSetName = ParameterName_BYGROUP)]
        public PlannerPlanPipeBind Plan;

        [Parameter(Mandatory = false, ParameterSetName = ParameterName_BYPLANID)]
        public string PlanId;

        [Parameter(Mandatory = true)]
        public string Title;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParameterName_BYGROUP)
            {
                var groupId = Group.GetGroupId(HttpClient, AccessToken);
                if (groupId != null)
                {
                    var plan = Plan.GetPlanAsync(HttpClient, AccessToken, groupId, false).GetAwaiter().GetResult();
                    if (plan != null)
                    {
                        WriteObject(PlannerUtility.UpdatePlanAsync(HttpClient, AccessToken, plan, Title).GetAwaiter().GetResult());
                    }
                    else
                    {
                        throw new PSArgumentException("Plan not found");
                    }
                }
                else
                {
                    throw new PSArgumentException("Group not found");
                }
            }
            else
            {
                var plan = PlannerUtility.GetPlanAsync(HttpClient, AccessToken, PlanId, false).GetAwaiter().GetResult();
                if (plan != null)
                {
                    WriteObject(PlannerUtility.UpdatePlanAsync(HttpClient, AccessToken, plan, Title).GetAwaiter().GetResult());
                }
                else
                {
                    throw new PSArgumentException("Plan not found");
                }
            }
        }
    }
}