---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/get-pnpgroup
schema: 2.0.0
title: Get-PnPGroup
---

# Get-PnPGroup

## SYNOPSIS
Returns a specific SharePoint group or all SharePoint groups in site.

## SYNTAX

### All (Default)
```powershell
Get-PnPGroup [-Web <WebPipeBind>] [-Connection <PnPConnection>] [-Includes <String[]>] [<CommonParameters>]
```

### ByName
```powershell
Get-PnPGroup [[-Identity] <GroupPipeBind>] [-Web <WebPipeBind>] [-Connection <PnPConnection>]
 [-Includes <String[]>] [<CommonParameters>]
```

### Members
```powershell
Get-PnPGroup [-AssociatedMemberGroup] [-Web <WebPipeBind>] [-Connection <PnPConnection>] [-Includes <String[]>]
 [<CommonParameters>]
```

### Visitors
```powershell
Get-PnPGroup [-AssociatedVisitorGroup] [-Web <WebPipeBind>] [-Connection <PnPConnection>]
 [-Includes <String[]>] [<CommonParameters>]
```

### Owners
```powershell
Get-PnPGroup [-AssociatedOwnerGroup] [-Web <WebPipeBind>] [-Connection <PnPConnection>] [-Includes <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Get-PnPGroup
```

Returns all SharePoint groups in a site

### EXAMPLE 2
```powershell
Get-PnPGroup -Identity 'My Site Users'
```

This will return the group called 'My Site Users' in if available in the current site

### EXAMPLE 3
```powershell
Get-PnPGroup -AssociatedMemberGroup
```

This will return the current members group for the site

## PARAMETERS

### -AssociatedMemberGroup
Retrieve the associated member group

```yaml
Type: SwitchParameter
Parameter Sets: Members

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssociatedOwnerGroup
Retrieve the associated owner group

```yaml
Type: SwitchParameter
Parameter Sets: Owners

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AssociatedVisitorGroup
Retrieve the associated visitor group

```yaml
Type: SwitchParameter
Parameter Sets: Visitors

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
Get a specific group by name

```yaml
Type: GroupPipeBind
Parameter Sets: ByName
Aliases: Name

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Web
The web to apply the command to. Omit this parameter to use the current web.

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

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)