﻿using System.Management.Automation;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using PnP.PowerShell.Commands.Utilities;

namespace PnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsCommon.New, "AzureCertificate")]
    public class NewPnPAdalCertificate : PSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0)]
        public string CommonName = "pnp.contoso.com";

        [Parameter(Mandatory = false, Position = 1)]
        public string Country = String.Empty;

        [Parameter(Mandatory = false, Position = 2)]
        public string State = string.Empty;

        [Parameter(Mandatory = false, Position = 3)]
        public string Locality = string.Empty;

        [Parameter(Mandatory = false, Position = 4)]
        public string Organization = string.Empty;

        [Parameter(Mandatory = false, Position = 5)]
        public string OrganizationUnit = string.Empty;

        [Parameter(Mandatory = false, Position = 6)]
        public string OutPfx;

        [Parameter(Mandatory = false, Position = 6)]
        public string OutCert;

        [Parameter(Mandatory = false, Position = 7)]
        public int ValidYears = 10;

        [Parameter(Mandatory = false, Position = 8)]
        public SecureString CertificatePassword;
        protected override void ProcessRecord()
        {
#if NETFRAMEWORK
            var x500Values = new List<string>();
            if (!string.IsNullOrWhiteSpace(CommonName)) x500Values.Add($"CN={CommonName}");
            if (!string.IsNullOrWhiteSpace(Country)) x500Values.Add($"C={Country}");
            if (!string.IsNullOrWhiteSpace(State)) x500Values.Add($"S={State}");
            if (!string.IsNullOrWhiteSpace(Locality)) x500Values.Add($"L={Locality}");
            if (!string.IsNullOrWhiteSpace(Organization)) x500Values.Add($"O={Organization}");
            if (!string.IsNullOrWhiteSpace(OrganizationUnit)) x500Values.Add($"OU={OrganizationUnit}");

            string x500 = string.Join("; ", x500Values);

            if (ValidYears < 1 || ValidYears > 30)
            {
                ValidYears = 10;
            }
            DateTime validFrom = DateTime.Today;
            DateTime validTo = validFrom.AddYears(ValidYears);

            byte[] certificateBytes = certificateBytes = CertificateHelper.CreateSelfSignCertificatePfx(x500, validFrom, validTo, CertificatePassword);
            var certificate = new X509Certificate2(certificateBytes, CertificatePassword, X509KeyStorageFlags.Exportable);
#else
            DateTimeOffset validFrom = DateTimeOffset.Now;
            DateTimeOffset validTo = validFrom.AddYears(ValidYears);
            var certificate = CertificateHelper.CreateSelfSignedCertificate2(CommonName, Country, State, Locality, Organization, OrganizationUnit, 2048, null, null, validFrom, validTo, "", false, null);
#endif

            if (!string.IsNullOrWhiteSpace(OutPfx))
            {
                if (!Path.IsPathRooted(OutPfx))
                {
                    OutPfx = Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, OutPfx);
                }
                byte[] certData = certificate.Export(X509ContentType.Pfx, CertificatePassword);
                File.WriteAllBytes(OutPfx, certData);
            }

            if (!string.IsNullOrWhiteSpace(OutCert))
            {
                if (!Path.IsPathRooted(OutCert))
                {
                    OutCert = Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, OutCert);
                }
                byte[] certData = certificate.Export(X509ContentType.Cert);
                File.WriteAllBytes(OutCert, certData);
            }

            var rawCert = certificate.GetRawCertData();
            var base64Cert = Convert.ToBase64String(rawCert);
            var rawCertHash = certificate.GetCertHash();
            var base64CertHash = Convert.ToBase64String(rawCertHash);
            var keyId = Guid.NewGuid();

            var template = @"
{{
    ""customKeyIdentifier"": ""{0}"",
    ""keyId"": ""{1}"",
    ""type"": ""AsymmetricX509Cert"",
    ""usage"": ""Verify"",
    ""value"":  ""{2}""
}}
";
            var manifestEntry = string.Format(template, base64CertHash, keyId, base64Cert);

            var record = new PSObject();
            record.Properties.Add(new PSVariableProperty(new PSVariable("Subject", certificate.Subject)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("ValidFrom", certificate.NotBefore)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("ValidTo", certificate.NotAfter)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("Thumbprint", certificate.Thumbprint)));

            record.Properties.Add(new PSVariableProperty(new PSVariable("KeyCredentials", manifestEntry)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("Certificate", CertificateHelper.CertificateToBase64(certificate))));
            record.Properties.Add(new PSVariableProperty(new PSVariable("PrivateKey", CertificateHelper.PrivateKeyToBase64(certificate))));

            WriteObject(record);
        }
    }
}
