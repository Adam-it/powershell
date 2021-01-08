---
external help file: PnP.PowerShell.dll-Help.xml
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/register-pnpazureadapp
applicable: SharePoint Online
schema: 2.0.0
title: Register-PnPAzureADApp
---

# Register-PnPAzureADApp

## SYNOPSIS
Register an Azure AD App and optionally creates a new self-signed certificate to use with the application registration.

## SYNTAX 

### Generate Certificate
```powershell
Register-PnPAzureADApp -ApplicationName <String>
                                       -Tenant <String>
                                       [-Username <String>]
                                       [-Password <SecureString>]
                                       [-DeviceLogin]
                                       [-CommonName <String>]
                                       [-OutPath <String>]
                                       [-Store <StoreLocation>]
                                       [-Scopes <String[]>]
                                       [-Country <String>]
                                       [-State <String>]
                                       [-Locality <String>]
                                       [-Organization <String>]
                                       [-OrganizationUnit <String>]
                                       [-ValidYears <Int>]
                                       [-CertificatePassword <SecureString>]
```

### Existing Certificate
```powershell
Register-PnPAzureADApp -CertificatePath <String>
                                       -ApplicationName <String>
                                       -Tenant <String>
                                       [-Username <String>]
                                       [-Password <SecureString>]
                                       [-DeviceLogin]
                                       [-Scopes <String[]>]
                                       [-CertificatePassword <SecureString>]
```

## DESCRIPTION
Registers an Azure AD App and optionally creates a new self-signed certificate to use with the application registration. Have a look at https://www.youtube.com/watch?v=QWY7AJ2ZQYI for a demonstration on how this cmdlet works and can be used. You can login either with username/password or you can use the -DeviceLogin option if your tenant has been configured for Multi-Factor Authentication.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
Register-PnPAzureADApp -ApplicationName TestApp -Tenant yourtenant.onmicrosoft.com -Store CurrentUser -Username "yourname@domain.com" -Password (Read-Host -AsSecureString -Prompt "Enter Password")
```

Creates a new Azure AD Application registration, creates a new self signed certificate, and adds it to the local certificate store. It will upload the certificate to the azure app registration and it will request the following permissions: Sites.FullControl.All, Group.ReadWrite.All, User.Read.All

### ------------------EXAMPLE 2------------------
```powershell
Register-PnPAzureADApp -ApplicationName TestApp -Tenant yourtenant.onmicrosoft.com -CertificatePath c:\certificate.pfx -CertificatePassword (ConvertTo-SecureString -String "password" -AsPlainText -Force) -Username "yourname@domain.com" -Password (Read-Host -AsSecureString -Prompt "Enter password")
```

Creates a new Azure AD Application registration which will use the existing private key certificate at the provided path to allow access. It will upload the provided private key certificate to the azure app registration and it will request the following permissions: Sites.FullControl.All, Group.ReadWrite.All, User.Read.All

### ------------------EXAMPLE 3------------------
```powershell
Register-PnPAzureADApp -ApplicationName TestApp -Tenant yourtenant.onmicrosoft.com -Store CurrentUser -Scopes "MSGraph.User.Read.All","SPO.Sites.Read.All" -Username "yourname@domain.com" -Password (Read-Host -AsSecureString -Prompt "Enter Password")
```

Creates a new Azure AD Application registration, creates a new self signed certificate, and adds it to the local certificate store. It will upload the certificate to the azure app registration and it will request the following permissions: Sites.Read.All, User.Read.All

### ------------------EXAMPLE 4------------------
```powershell
Register-PnPAzureADApp -ApplicationName TestApp -Tenant yourtenant.onmicrosoft.com -OutPath c:\ -CertificatePassword (ConvertTo-SecureString -String "password" -AsPlainText -Force) -Username "yourname@domain.com" -Password (Read-Host -AsSecureString -Prompt "Enter Password")
```

Creates a new Azure AD Application registration, creates a new self signed certificate, and stores the public and private key certificates in c:\. The private key certificate will be locked with the password "password". It will upload the certificate to the azure app registration and it will request the following permissions: Sites.FullControl.All, Group.ReadWrite.All, User.Read.All

### ------------------EXAMPLE 5------------------
```powershell
Register-PnPAzureADApp -DeviceLogin -ApplicationName TestApp -Tenant yourtenant.onmicrosoft.com -CertificatePath c:\certificate.pfx -CertificatePassword (ConvertTo-SecureString -String "password" -AsPlainText -Force) 
```

Creates a new Azure AD Application registration and asks you to authenticate using device login methods, creates a new self signed certificate, and adds it to the local certificate store. It will upload the certificate to the azure app registration and it will request the following permissions: Sites.FullControl.All, Group.ReadWrite.All, User.Read.All

## PARAMETERS

### -Username
The username to use when logging into the Microsoft Graph. Notice that this user account needs to have write access to the Azure AD

```yaml
Type: String
Parameter Sets: __AllParameterSets

Required: False
Position: Named
Accept pipeline input: False
```

### -Password
The password to use when logging into the Microsoft Graph

```yaml
Type: String
Parameter Sets: __AllParameterSets

Required: False
Position: Named
Accept pipeline input: False
```

### -DeviceLogin
If specified, a device login flow, supporting Multi-Factor Authentication will be used to authenticate towards the Microsoft Graph

```yaml
Type: SwitchParameter
Parameter Sets: __AllParameterSets

Required: False
Position: Named
Accept pipeline input: False
```

### -ApplicationName
The name of the Azure AD Application to create

```yaml
Type: String
Parameter Sets: __AllParameterSets

Required: True
Position: Named
Accept pipeline input: False
```

### -CertificatePassword
Optional certificate password

```yaml
Type: SecureString
Parameter Sets: Generate Certificate, Existing Certificate

Required: False
Position: 8
Accept pipeline input: False
```

### -CertificatePath
File path to use an existing certificate

```yaml
Type: String
Parameter Sets: Existing Certificate

Required: True
Position: Named
Accept pipeline input: False
```

### -CommonName
Common Name (e.g. server FQDN or YOUR name). defaults to 'pnp.contoso.com'

```yaml
Type: String
Parameter Sets: Generate Certificate

Required: False
Position: 0
Accept pipeline input: False
```

### -Country
Country Name (2 letter code)

```yaml
Type: String
Parameter Sets: Generate Certificate

Required: False
Position: 1
Accept pipeline input: False
```

### -Locality
Locality Name (eg, city)

```yaml
Type: String
Parameter Sets: Generate Certificate

Required: False
Position: 3
Accept pipeline input: False
```

### -Organization
Organization Name (eg, company)

```yaml
Type: String
Parameter Sets: Generate Certificate

Required: False
Position: 4
Accept pipeline input: False
```

### -OrganizationUnit
Organizational Unit Name (eg, section)

```yaml
Type: String
Parameter Sets: Generate Certificate

Required: False
Position: 5
Accept pipeline input: False
```

### -OutPath
Folder to create certificate files in (.CER and .PFX)

```yaml
Type: String
Parameter Sets: Generate Certificate

Required: False
Position: Named
Accept pipeline input: False
```

### -Scopes
Specify which permissions scopes to request.

```yaml
Type: String[]
Parameter Sets: Generate Certificate

Required: False
Position: 0
Accept pipeline input: False
```

### -State
State or Province Name (full name)

```yaml
Type: String
Parameter Sets: Generate Certificate

Required: False
Position: 2
Accept pipeline input: False
```

### -Store
Local Certificate Store to add the certificate to

```yaml
Type: StoreLocation
Parameter Sets: Generate Certificate

Required: False
Position: Named
Accept pipeline input: False
```

### -Tenant
The identifier of your tenant, e.g. mytenant.onmicrosoft.com

```yaml
Type: String
Parameter Sets: __AllParameterSets

Required: True
Position: Named
Accept pipeline input: False
```

### -ValidYears
Number of years until expiration (default is 10, max is 30)

```yaml
Type: Int
Parameter Sets: Generate Certificate

Required: False
Position: 7
Accept pipeline input: False
```

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)
