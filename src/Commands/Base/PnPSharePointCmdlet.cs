﻿using System;
using System.Management.Automation;
using System.Reflection;
using System.Threading;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using PnP.Core.Services;
using PnP.Framework;
using PnP.Framework.Utilities;
using PnP.PowerShell.Commands.Base;
using Resources = PnP.PowerShell.Commands.Properties.Resources;


namespace PnP.PowerShell.Commands
{
    /// <summary>
    /// Base class for all the PnP SharePoint related cmdlets
    /// </summary>
    public class PnPSharePointCmdlet : PnPConnectedCmdlet
    {
        /// <summary>
        /// Reference the the SharePoint context on the current connection. If NULL it means there is no SharePoint context available on the current connection.
        /// </summary>
        public ClientContext ClientContext => Connection?.Context ?? PnPConnection.CurrentConnection.Context;

        public PnPContext PnPContext => Connection?.PnPContext ?? PnPConnection.CurrentConnection.PnPContext;

        // do not remove '#!#99'
        [Parameter(Mandatory = false, HelpMessage = "Optional connection to be used by the cmdlet. Retrieve the value for this parameter by either specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.")]
        public PnPConnection Connection = null;
        // do not remove '#!#99'

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (PnPConnection.CurrentConnection != null && PnPConnection.CurrentConnection.ApplicationInsights != null)
            {
                PnPConnection.CurrentConnection.ApplicationInsights.TrackEvent(MyInvocation.MyCommand.Name);
            }

            if (Connection == null && ClientContext == null)
            {
                throw new InvalidOperationException(Resources.NoSharePointConnection);
            }
        }

        protected override void ProcessRecord()
        {
            try
            {
                var tag = PnPConnection.CurrentConnection.PnPVersionTag + ":" + MyInvocation.MyCommand.Name;
                if (tag.Length > 32)
                {
                    tag = tag.Substring(0, 32);
                }
                ClientContext.ClientTag = tag;

                ExecuteCmdlet();
            }
            catch (PipelineStoppedException)
            {
                //don't swallow pipeline stopped exception
                //it makes select-object work weird
                throw;
            }
            catch (Exception ex)
            {
                PnPConnection.CurrentConnection.RestoreCachedContext(PnPConnection.CurrentConnection.Url);
                ex.Data.Add("CorrelationId", PnPConnection.CurrentConnection.Context.TraceCorrelationId);
                ex.Data.Add("TimeStampUtc", DateTime.UtcNow);
                var errorDetails = new ErrorDetails(ex.Message);

                errorDetails.RecommendedAction = "Use Get-PnPException for more details.";
                var errorRecord = new ErrorRecord(ex, "EXCEPTION", ErrorCategory.WriteError, null);
                errorRecord.ErrorDetails = errorDetails;

                WriteError(errorRecord);
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected string AccessToken
        {
            get
            {
                if (PnPConnection.CurrentConnection != null)
                {
                    if (PnPConnection.CurrentConnection.Context != null)
                    {
                        var settings = Microsoft.SharePoint.Client.InternalClientContextExtensions.GetContextSettings(PnPConnection.CurrentConnection.Context);
                        if (settings != null)
                        {
                            var authManager = settings.AuthenticationManager;
                            if (authManager != null)
                            {
                                return authManager.GetAccessTokenAsync(PnPConnection.CurrentConnection.Context.Url).GetAwaiter().GetResult();
                            }
                        }
                    }
                }
                return null;
            }
        }

        protected void PollOperation(SpoOperation spoOperation)
        {
            while (true)
            {
                if (!spoOperation.IsComplete)
                {
                    if (spoOperation.HasTimedout)
                    {
                        throw new TimeoutException("SharePoint Operation Timeout");
                    }
                    Thread.Sleep(spoOperation.PollingInterval);
                    if (Stopping)
                    {
                        break;
                    }
                    ClientContext.Load(spoOperation);
                    ClientContext.ExecuteQueryRetry();
                    continue;
                }
                return;
            }
            WriteWarning("SharePoint Operation Wait Interrupted");
        }

    }
}
