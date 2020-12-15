﻿using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace PnP.PowerShell.Commands.Utilities
{
    public static class AzureAuthHelper
    {
        private static string CLIENTID = "1950a258-227b-4e31-a9cf-717495945fc2"; // Well-known Azure Management App Id
        internal static async Task<string> AuthenticateAsync(string tenantId, string username, SecureString password, string loginEndPoint = "https://login.microsoftonline.com")
        {
            if (string.IsNullOrEmpty(tenantId))
            {
                throw new ArgumentException($"{nameof(tenantId)} is required");
            }

            var authority = $"{loginEndPoint}/{tenantId}";
            var scopes = new string[] { "https://graph.microsoft.com/.default" };
            var app = PublicClientApplicationBuilder.Create(CLIENTID).WithAuthority(authority).Build();

            var result = await app.AcquireTokenByUsernamePassword(scopes, username, password).ExecuteAsync();
            return result.AccessToken;
        }

        internal static string AuthenticateDeviceLogin(string tenantId, ref CancellationToken cancellationToken, PowerShellMessageWriter messageWriter ,string loginEndPoint = "https://login.microsoftonline.com")
        {
            if (string.IsNullOrEmpty(tenantId))
            {
                throw new ArgumentException($"{nameof(tenantId)} is required");
            }
            var authority = $"{loginEndPoint}/{tenantId}";


            var app = PublicClientApplicationBuilder.Create(CLIENTID).WithAuthority(authority).Build();
            var scopes = new string[] { "https://graph.microsoft.com/.default" };

            var tokenResult = app.AcquireTokenWithDeviceCode(scopes, result =>
            {
                messageWriter.WriteMessage(result.Message);
                return Task.FromResult(0);
            }).ExecuteAsync(cancellationToken).GetAwaiter().GetResult();
            return tokenResult.AccessToken;
        }
    }
}