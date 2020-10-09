---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/set-pnpgrouppermissions
schema: 2.0.0
title: Set-PnPGroupPermissions
---

# Set-PnPGroupPermissions

## SYNOPSIS
Adds and/or removes permissions of a specific SharePoint group

## SYNTAX

```powershell
Set-PnPGroupPermissions [-Identity] <GroupPipeBind> [-List <ListPipeBind>] [-AddRole <String[]>]
 [-RemoveRole <String[]>] [-Web <WebPipeBind>] [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Set-PnPGroupPermissions -Identity 'My Site Members' -AddRole Contribute
```

Adds the 'Contribute' permission to the SharePoint group with the name 'My Site Members'

### EXAMPLE 2
```powershell
Set-PnPGroupPermissions -Identity 'My Site Members' -RemoveRole 'Full Control' -AddRole 'Read'
```

Removes the 'Full Control' from and adds the 'Contribute' permissions to the SharePoint group with the name 'My Site Members'

### EXAMPLE 3
```powershell
Set-PnPGroupPermissions -Identity 'My Site Members' -AddRole @('Contribute', 'Design')
```

Adds the 'Contribute' and 'Design' permissions to the SharePoint group with the name 'My Site Members'

### EXAMPLE 4
```powershell
Set-PnPGroupPermissions -Identity 'My Site Members' -RemoveRole @('Contribute', 'Design')
```

Removes the 'Contribute' and 'Design' permissions from the SharePoint group with the name 'My Site Members'

### EXAMPLE 5
```powershell
Set-PnPGroupPermissions -Identity 'My Site Members' -List 'MyList' -RemoveRole @('Contribute')
```

Removes the 'Contribute' permissions from the list 'MyList' for the group with the name 'My Site Members'

## PARAMETERS

### -AddRole
Name of the permission set to add to this SharePoint group

```yaml
Type: String[]
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Connection
Optional connection to be used by the cmdlet. Retrieve the value for this parameter by either specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: PnPConnection
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Get the permissions of a specific group by name

```yaml
Type: GroupPipeBind
Parameter Sets: (All)
Aliases: Name

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
The list to apply the command to.

```yaml
Type: ListPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveRole
Name of the permission set to remove from this SharePoint group

```yaml
Type: String[]
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Web
This parameter allows you to optionally apply the cmdlet action to a subweb within the current web. In most situations this parameter is not required and you can connect to the subweb using Connect-PnPOnline instead. Specify the GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.

```yaml
Type: WebPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](https://aka.ms/sppnp)