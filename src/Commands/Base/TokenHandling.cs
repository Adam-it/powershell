﻿using Microsoft.SharePoint.Client;
using PnP.PowerShell.Commands.Model;
using System.Web;

namespace PnP.PowerShell.Commands.Base
{
    internal static class TokenHandler
    {
        internal static string AcquireToken(string resource, string scope = null)
        {
            GenericToken token = null;
            if (PnPConnection.CurrentConnection == null)
            {
                return null;
            }
            var tenantId = TenantExtensions.GetTenantIdByUrl(PnPConnection.CurrentConnection.Url);
            if (PnPConnection.CurrentConnection.PSCredential != null)
            {
                if (!string.IsNullOrEmpty(PnPConnection.CurrentConnection.ClientId))
                {
                    if (scope == null)
                    {
                        var scopes = new[] { $"https://{resource.Replace("https://", "").TrimEnd('/')}/.default" };
                        token = GenericToken.AcquireDelegatedTokenWithCredentials(PnPConnection.CurrentConnection.ClientId, scopes, "https://login.microsoftonline.com/organizations/", PnPConnection.CurrentConnection.PSCredential.UserName, PnPConnection.CurrentConnection.PSCredential.Password);
                    }
                    else
                    {
                        token = GenericToken.AcquireDelegatedTokenWithCredentials(PnPConnection.CurrentConnection.ClientId, new[] { scope }, "https://login.microsoftonline.com/organizations/", PnPConnection.CurrentConnection.PSCredential.UserName, PnPConnection.CurrentConnection.PSCredential.Password);
                    }
                }
                else
                {
                    if (scope == null)
                    {
                        // SharePoint or Graph V1 resource
                        var scopes = new[] { $"https://{resource.Replace("https://", "").TrimEnd('/')}/.default" };
                        token = GenericToken.AcquireDelegatedTokenWithCredentials(PnPConnection.PnPManagementShellClientId, scopes, "https://login.microsoftonline.com/organizations/", PnPConnection.CurrentConnection.PSCredential.UserName, PnPConnection.CurrentConnection.PSCredential.Password);
                    }
                    else
                    {
                        token = GenericToken.AcquireDelegatedTokenWithCredentials(PnPConnection.PnPManagementShellClientId, new[] { scope }, "https://login.microsoftonline.com/organizations/", PnPConnection.CurrentConnection.PSCredential.UserName, PnPConnection.CurrentConnection.PSCredential.Password);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(PnPConnection.CurrentConnection.ClientId) && !string.IsNullOrEmpty(PnPConnection.CurrentConnection.ClientSecret))
            {
                var clientId = PnPConnection.CurrentConnection.ClientId;
                var clientSecret = System.Net.WebUtility.UrlEncode(PnPConnection.CurrentConnection.ClientSecret);
                if (scope == null && !resource.Equals("graph.microsoft.com", System.StringComparison.OrdinalIgnoreCase))
                {
                    // SharePoint token
                    var scopes = new[] { $"https://{resource}//.default" };
                    token = GenericToken.AcquireApplicationToken(tenantId, clientId, "https://login.microsoftonline/organizations/", scopes, clientSecret);
                }
                else
                {
                    token = GenericToken.AcquireApplicationToken(tenantId, clientId, "https://login.microsoftonline.com/organizations/", new[] { scope }, clientSecret);
                }
            }
            else if (!string.IsNullOrEmpty(PnPConnection.CurrentConnection.ClientId) && PnPConnection.CurrentConnection.Certificate != null)
            {
                var clientId = PnPConnection.CurrentConnection.ClientId;
                var certificate = PnPConnection.CurrentConnection.Certificate;
                if (scope == null && !resource.Equals("graph.microsoft.com", System.StringComparison.OrdinalIgnoreCase))
                {
                    // SharePoint token
                    var scopes = new[] { $"https://{resource}//.default" };
                    token = GenericToken.AcquireApplicationToken(tenantId, clientId, "https://login.microsoftonline/organizations/", scopes, certificate);
                }
                else
                {
                    token = GenericToken.AcquireApplicationToken(tenantId, clientId, "https://login.microsoftonline/organizations/", new[] { scope }, certificate);
                }
            }
            if (token != null)
            {
                return token.AccessToken;
            }
            return null;
        }

        //internal static string AcquireToken(string resource, string scope = null)
        //{
        //    if (PnPConnection.CurrentConnection == null)
        //    {
        //        return null;
        //    }

        //    var tenantId = TenantExtensions.GetTenantIdByUrl(PnPConnection.CurrentConnection.Url);

        //    if (tenantId == null) return null;

        //    string body = "";
        //    if (PnPConnection.CurrentConnection.PSCredential != null)
        //    {
        //        var clientId = "31359c7f-bd7e-475c-86db-fdb8c937548e";
        //        var username = PnPConnection.CurrentConnection.PSCredential.UserName;
        //        var password = EncryptionUtility.ToInsecureString(PnPConnection.CurrentConnection.PSCredential.Password);
        //        body = $"grant_type=password&client_id={clientId}&username={username}&password={password}&resource=https://{resource}";
        //    }
        //    else if (!string.IsNullOrEmpty(PnPConnection.CurrentConnection.ClientId) && !string.IsNullOrEmpty(PnPConnection.CurrentConnection.ClientSecret))
        //    {
        //        var clientId = PnPConnection.CurrentConnection.ClientId;
        //        var clientSecret = HttpUtility.UrlEncode(PnPConnection.CurrentConnection.ClientSecret);
        //        body = $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}&resource=https://{resource}";
        //    }
        //    else
        //    {
        //        throw new System.UnauthorizedAccessException("Specify PowerShell Credentials or AppId and AppSecret");
        //    }

        //    var response = HttpHelper.MakePostRequestForString($"https://login.microsoftonline.com/{tenantId}/oauth2/token", body, "application/x-www-form-urlencoded");
        //    try
        //    {
        //        using (var jdoc = JsonDocument.Parse(response))
        //        {
        //            return jdoc.RootElement.GetProperty("access_token").GetString();
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
