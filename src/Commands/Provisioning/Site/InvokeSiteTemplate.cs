﻿using System;
using System.IO;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using PnP.Framework.Provisioning.Model;

using PnP.Framework.Provisioning.Providers.Xml;
using PnP.Framework.Provisioning.Connectors;
using PnP.Framework.Provisioning.ObjectHandlers;
using System.Collections;
using System.Linq;
using PnP.Framework.Provisioning.Providers;
using System.Collections.Generic;
using PnP.PowerShell.Commands.Utilities;
using PnP.PowerShell.Commands.Base;
using System.Threading.Tasks;

namespace PnP.PowerShell.Commands.Provisioning.Site
{
    [Cmdlet(VerbsLifecycle.Invoke, "SiteTemplate")]
    public class InvokeSiteTemplate : PnPWebCmdlet
    {
        private ProgressRecord progressRecord = new ProgressRecord(0, "Activity", "Status");
        private ProgressRecord subProgressRecord = new ProgressRecord(1, "Activity", "Status");


        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, ParameterSetName = "Path")]
        public string Path;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string TemplateId;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string ResourceFolder;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SwitchParameter OverwriteSystemPropertyBagValues;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SwitchParameter IgnoreDuplicateDataRowErrors;

        [Parameter(Mandatory = false)]
        public SwitchParameter ProvisionContentTypesToSubWebs;

        [Parameter(Mandatory = false)]
        public SwitchParameter ProvisionFieldsToSubWebs;

        [Parameter(Mandatory = false)]
        public SwitchParameter ClearNavigation;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public Hashtable Parameters;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public Handlers Handlers;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public Handlers ExcludeHandlers;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ExtensibilityHandler[] ExtensibilityHandlers;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ITemplateProviderExtension[] TemplateProviderExtensions;

        [Parameter(Mandatory = false, ParameterSetName = "Instance")]
        public ProvisioningTemplate InputInstance;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.EnsureProperty(w => w.Url);
            ProvisioningTemplate provisioningTemplate;

            FileConnectorBase fileConnector;
            if (ParameterSpecified(nameof(Path)))
            {
                bool templateFromFileSystem = !Path.ToLower().StartsWith("http");
                string templateFileName = System.IO.Path.GetFileName(Path);
                if (templateFromFileSystem)
                {
                    if (!System.IO.Path.IsPathRooted(Path))
                    {
                        Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
                    }
                    if (!System.IO.File.Exists(Path))
                    {
                        throw new FileNotFoundException($"File not found");
                    }
                    if (!string.IsNullOrEmpty(ResourceFolder))
                    {
                        if (!System.IO.Path.IsPathRooted(ResourceFolder))
                        {
                            ResourceFolder = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path,
                                ResourceFolder);
                        }
                    }
                    var fileInfo = new FileInfo(Path);
                    fileConnector = new FileSystemConnector(fileInfo.DirectoryName, "");
                }
                else
                {
                    Uri fileUri = new Uri(Path);
                    var webUrl = Microsoft.SharePoint.Client.Web.WebUrlFromFolderUrlDirect(ClientContext, fileUri);
                    var templateContext = ClientContext.Clone(webUrl.ToString());

                    var library = Path.ToLower().Replace(templateContext.Url.ToLower(), "").TrimStart('/');
                    var idx = library.IndexOf("/", StringComparison.Ordinal);
                    library = library.Substring(0, idx);

                    // This syntax creates a SharePoint connector regardless we have the -InputInstance argument or not
                    fileConnector = new SharePointConnector(templateContext, templateContext.Url, library);
                }

                // If we don't have the -InputInstance parameter, we load the template from the source connector

                Stream stream = fileConnector.GetFileStream(templateFileName);
                var isOpenOfficeFile = FileUtilities.IsOpenOfficeFile(stream);
                XMLTemplateProvider provider;
                if (isOpenOfficeFile)
                {
                    var openXmlConnector = new OpenXMLConnector(templateFileName, fileConnector);
                    provider = new XMLOpenXMLTemplateProvider(openXmlConnector);
                    if (!String.IsNullOrEmpty(openXmlConnector.Info?.Properties?.TemplateFileName))
                    {
                        templateFileName = openXmlConnector.Info.Properties.TemplateFileName;
                    }
                    else
                    {
                        templateFileName = templateFileName.Substring(0, templateFileName.LastIndexOf(".", StringComparison.Ordinal)) + ".xml";
                    }
                }
                else
                {
                    if (templateFromFileSystem)
                    {
                        provider = new XMLFileSystemTemplateProvider(fileConnector.Parameters[FileConnectorBase.CONNECTIONSTRING] + "", "");
                    }
                    else
                    {
                        throw new NotSupportedException("Only .pnp package files are supported from a SharePoint library");
                    }
                }

                if (ParameterSpecified(nameof(TemplateId)))
                {
                    provisioningTemplate = provider.GetTemplate(templateFileName, TemplateId, null, TemplateProviderExtensions);
                }
                else
                {
                    provisioningTemplate = provider.GetTemplate(templateFileName, TemplateProviderExtensions);
                }

                if (provisioningTemplate == null)
                {
                    // If we don't have the template, raise an error and exit
                    WriteError(new ErrorRecord(new Exception("The -Path parameter targets an invalid repository or template object."), "WRONG_PATH", ErrorCategory.SyntaxError, null));
                    return;
                }

                if (isOpenOfficeFile)
                {
                    provisioningTemplate.Connector = provider.Connector;
                }
                else
                {
                    if (ResourceFolder != null)
                    {
                        var fileSystemConnector = new FileSystemConnector(ResourceFolder, "");
                        provisioningTemplate.Connector = fileSystemConnector;
                    }
                    else
                    {
                        provisioningTemplate.Connector = provider.Connector;
                    }
                }
            }

            else
            {
                provisioningTemplate = InputInstance;

                if (ResourceFolder != null)
                {
                    var fileSystemConnector = new FileSystemConnector(ResourceFolder, "");
                    provisioningTemplate.Connector = fileSystemConnector;
                }
                else
                {
                    if (Path != null)
                    {
                        if (!System.IO.Path.IsPathRooted(Path))
                        {
                            Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
                        }
                    }
                    else
                    {
                        Path = SessionState.Path.CurrentFileSystemLocation.Path;
                    }
                    var fileInfo = new FileInfo(Path);
                    fileConnector = new FileSystemConnector(System.IO.Path.IsPathRooted(fileInfo.FullName) ? fileInfo.FullName : fileInfo.DirectoryName, "");
                    provisioningTemplate.Connector = fileConnector;
                }
            }

            if (Parameters != null)
            {
                foreach (var parameter in Parameters.Keys)
                {
                    if (provisioningTemplate.Parameters.ContainsKey(parameter.ToString()))
                    {
                        provisioningTemplate.Parameters[parameter.ToString()] = Parameters[parameter].ToString();
                    }
                    else
                    {
                        provisioningTemplate.Parameters.Add(parameter.ToString(), Parameters[parameter].ToString());
                    }
                }
            }

            var applyingInformation = new ProvisioningTemplateApplyingInformation();

            if (ParameterSpecified(nameof(Handlers)))
            {
                applyingInformation.HandlersToProcess = Handlers;
            }
            if (ParameterSpecified(nameof(ExcludeHandlers)))
            {
                foreach (var handler in (Handlers[])Enum.GetValues(typeof(Handlers)))
                {
                    if (!ExcludeHandlers.Has(handler) && handler != Handlers.All)
                    {
                        Handlers = Handlers | handler;
                    }
                }
                applyingInformation.HandlersToProcess = Handlers;
            }

            if (ExtensibilityHandlers != null)
            {
                applyingInformation.ExtensibilityHandlers = ExtensibilityHandlers.ToList();
            }

            applyingInformation.ProgressDelegate = (message, step, total) =>
            {
                if (message != null)
                {
                    var percentage = Convert.ToInt32((100 / Convert.ToDouble(total)) * Convert.ToDouble(step));
                    progressRecord.Activity = $"Applying template to {SelectedWeb.Url}";
                    progressRecord.StatusDescription = message;
                    progressRecord.PercentComplete = percentage;
                    progressRecord.RecordType = ProgressRecordType.Processing;
                    WriteProgress(progressRecord);
                }
            };

            var warningsShown = new List<string>();

            applyingInformation.MessagesDelegate = (message, type) =>
            {
                switch (type)
                {
                    case ProvisioningMessageType.Warning:
                        {
                            if (!warningsShown.Contains(message))
                            {
                                WriteWarning(message);
                                warningsShown.Add(message);
                            }
                            break;
                        }
                    case ProvisioningMessageType.Progress:
                        {
                            if (message != null)
                            {
                                var activity = message;
                                if (message.IndexOf("|") > -1)
                                {
                                    var messageSplitted = message.Split('|');
                                    if (messageSplitted.Length == 4)
                                    {
                                        var current = double.Parse(messageSplitted[2]);
                                        var total = double.Parse(messageSplitted[3]);
                                        subProgressRecord.RecordType = ProgressRecordType.Processing;
                                        subProgressRecord.Activity = string.IsNullOrEmpty(messageSplitted[0]) ? "-" : messageSplitted[0];
                                        subProgressRecord.StatusDescription = string.IsNullOrEmpty(messageSplitted[1]) ? "-" : messageSplitted[1];
                                        subProgressRecord.PercentComplete = Convert.ToInt32((100 / total) * current);
                                        WriteProgress(subProgressRecord);
                                    }
                                    else
                                    {
                                        subProgressRecord.Activity = "Processing";
                                        subProgressRecord.RecordType = ProgressRecordType.Processing;
                                        subProgressRecord.StatusDescription = activity;
                                        subProgressRecord.PercentComplete = 0;
                                        WriteProgress(subProgressRecord);
                                    }
                                }
                                else
                                {
                                    subProgressRecord.Activity = "Processing";
                                    subProgressRecord.RecordType = ProgressRecordType.Processing;
                                    subProgressRecord.StatusDescription = activity;
                                    subProgressRecord.PercentComplete = 0;
                                    WriteProgress(subProgressRecord);
                                }
                            }
                            break;
                        }
                    case ProvisioningMessageType.Completed:
                        {

                            WriteProgress(new ProgressRecord(1, message, " ") { RecordType = ProgressRecordType.Completed });
                            break;
                        }
                }
            };

            applyingInformation.OverwriteSystemPropertyBagValues = OverwriteSystemPropertyBagValues;
            applyingInformation.IgnoreDuplicateDataRowErrors = IgnoreDuplicateDataRowErrors;
            applyingInformation.ClearNavigation = ClearNavigation;
            applyingInformation.ProvisionContentTypesToSubWebs = ProvisionContentTypesToSubWebs;
            applyingInformation.ProvisionFieldsToSubWebs = ProvisionFieldsToSubWebs;

            using (var provisioningContext = new PnPProvisioningContext(async (resource, scope) =>
            {
                if (resource.ToLower().StartsWith("https://"))
                {
                    var uri = new Uri(resource);
                    resource = uri.Authority;
                }
                // Get Azure AD Token
                if (PnPConnection.CurrentConnection != null)
                {
                    var graphAccessToken = await PnPConnection.CurrentConnection.TryGetAccessTokenAsync(Enums.TokenAudience.MicrosoftGraph);
                    if (graphAccessToken != null)
                    {
                        // Authenticated using -Graph or using another way to retrieve the accesstoken with Connect-PnPOnline
                        return graphAccessToken;

                    }
                }

                if (PnPConnection.CurrentConnection.PSCredential != null)
                {
                    // Using normal credentials
                    return await TokenHandler.AcquireTokenAsync(resource, null);
                }
                else
                {
                    // No token...
                    if (resource.ToLower().Contains(".sharepoint."))
                    {
                        return null;
                    }
                    else
                    {
                        throw new PSInvalidOperationException($"Your template contains artifacts that require an access token for {resource}. Please provide consent to the PnP Management Shell application first by executing: Register-PnPManagementShellAccess");
                    }
                }
            }))
            {
                SelectedWeb.ApplyProvisioningTemplate(provisioningTemplate, applyingInformation);
            }

            WriteProgress(new ProgressRecord(0, $"Applying template to {SelectedWeb.Url}", " ") { RecordType = ProgressRecordType.Completed });
        }
    }
}
