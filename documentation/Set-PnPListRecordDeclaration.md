---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/set-pnplistrecorddeclaration
schema: 2.0.0
title: Set-PnPListRecordDeclaration
---

# Set-PnPListRecordDeclaration

## SYNOPSIS
The RecordDeclaration parameter supports 4 values:

AlwaysAllowManualDeclaration
NeverAllowManualDeclaration
UseSiteCollectionDefaults

## SYNTAX

```powershell
Set-PnPListRecordDeclaration -List <ListPipeBind> [-ManualRecordDeclaration <EcmListManualRecordDeclaration>]
 [-AutoRecordDeclaration <Boolean>] [-Web <WebPipeBind>] [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Set-PnPListRecordDeclaration -List "Documents" -ManualRecordDeclaration NeverAllowManualDeclaration
```

Sets the manual record declaration to never allow

### EXAMPLE 2
```powershell
Set-PnPListRecordDeclaration -List "Documents" -AutoRecordDeclaration $true
```

Turns on auto record declaration for the list

## PARAMETERS

### -AutoRecordDeclaration
Defines if you want to set auto record declaration on the list

```yaml
Type: Boolean
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

### -List
The List to set the manual record declaration settings for

```yaml
Type: ListPipeBind
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManualRecordDeclaration
Defines the manual record declaration setting for the lists

```yaml
Type: EcmListManualRecordDeclaration
Parameter Sets: (All)
Accepted values: Unknown, UseSiteCollectionDefaults, AlwaysAllowManualDeclaration, NeverAllowManualDeclaration

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