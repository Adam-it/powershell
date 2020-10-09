---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/new-pnpupabulkimportjob
schema: 2.0.0
title: New-PnPUPABulkImportJob
---

# New-PnPUPABulkImportJob

## SYNOPSIS

**Required Permissions**

* SharePoint: Access to the SharePoint Tenant Administration site

Submit up a new user profile bulk import job.

## SYNTAX

```powershell
New-PnPUPABulkImportJob [-Folder] <String> [-Path] <String> [-UserProfilePropertyMapping] <Hashtable>
 [-IdProperty] <String> [[-IdType] <ImportProfilePropertiesUserIdType>] [-Connection <PnPConnection>]
 [<CommonParameters>]
```

## DESCRIPTION
See https://docs.microsoft.com/sharepoint/dev/solution-guidance/bulk-user-profile-update-api-for-sharepoint-online for information on the API and how the bulk import process works.

## EXAMPLES

### EXAMPLE 1
```powershell
@" 
 {
  "value": [
    {
      "IdName": "mikaels@contoso.com",
      "Department": "PnP",
    },
	{
      "IdName": "vesaj@contoso.com",
      "Department": "PnP",
    }    
  ]
}
"@ > profiles.json

New-PnPUPABulkImportJob -Folder "Shared Documents" -Path profiles.json -IdProperty "IdName" -UserProfilePropertyMapping @{"Department"="Department"}
```

This will submit a new user profile bulk import job to SharePoint Online.

## PARAMETERS

### -Connection
Optional connection to be used by the cmdlet. Retrieve the value for this parameter by either specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: PnPConnection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Folder
Site or server relative URL of the folder to where you want to store the import job file.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdProperty
The name of the identifying property in your file.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdType
The type of profile identifier (Email/CloudId/PrincipalName). Defaults to Email.

```yaml
Type: ImportProfilePropertiesUserIdType
Parameter Sets: (All)
Aliases:
Accepted values: Email, CloudId, PrincipalName

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
The local file path.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserProfilePropertyMapping
Specify user profile property mapping between the import file and UPA property names.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](https://aka.ms/sppnp)