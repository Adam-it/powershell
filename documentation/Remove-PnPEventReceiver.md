---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/remove-pnpeventreceiver
schema: 2.0.0
title: Remove-PnPEventReceiver
---

# Remove-PnPEventReceiver

## SYNOPSIS
Remove an eventreceiver

## SYNTAX

```powershell
Remove-PnPEventReceiver -Identity <EventReceiverPipeBind> [-List <ListPipeBind>] [-Force] [-Web <WebPipeBind>]
 [-Connection <PnPConnection>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Removes/unregisters a specific eventreceiver

## EXAMPLES

### EXAMPLE 1
```powershell
Remove-PnPEventReceiver -Identity fb689d0e-eb99-4f13-beb3-86692fd39f22
```

This will remove the event receiver with ReceiverId "fb689d0e-eb99-4f13-beb3-86692fd39f22" from the current web

### EXAMPLE 2
```powershell
Remove-PnPEventReceiver -List ProjectList -Identity fb689d0e-eb99-4f13-beb3-86692fd39f22
```

This will remove the event receiver with ReceiverId "fb689d0e-eb99-4f13-beb3-86692fd39f22" from the "ProjectList" list

### EXAMPLE 3
```powershell
Remove-PnPEventReceiver -List ProjectList -Identity MyReceiver
```

This will remove the event receiver with ReceiverName "MyReceiver" from the "ProjectList" list

### EXAMPLE 4
```powershell
Remove-PnPEventReceiver -List ProjectList
```

This will remove all event receivers from the "ProjectList" list

### EXAMPLE 5
```powershell
Remove-PnPEventReceiver
```

This will remove all event receivers from the current site

### EXAMPLE 6
```powershell
Get-PnPEventReceiver | ? ReceiverUrl -Like "*azurewebsites.net*" | Remove-PnPEventReceiver
```

This will remove all event receivers from the current site which are pointing to a service hosted on Azure Websites

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

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

### -Force
Specifying the Force parameter will skip the confirmation question

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
The Guid of the event receiver on the list

```yaml
Type: EventReceiverPipeBind
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -List
The list object from where to remove the event receiver object

```yaml
Type: ListPipeBind
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

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](https://aka.ms/sppnp)