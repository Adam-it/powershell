---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://pnp.github.io/powershell/cmdlets/get-pnppropertybag
schema: 2.0.0
title: Get-PnPPropertyBag
---

# Get-PnPPropertyBag

## SYNOPSIS
Returns the property bag values.

## SYNTAX

```powershell
Get-PnPPropertyBag [[-Key] <String>] [-Folder <String>] [-Web <WebPipeBind>] [-Connection <PnPConnection>]
 [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Get-PnPPropertyBag
```

This will return all web property bag values

### EXAMPLE 2
```powershell
Get-PnPPropertyBag -Key MyKey
```

This will return the value of the key MyKey from the web property bag

### EXAMPLE 3
```powershell
Get-PnPPropertyBag -Folder /MyFolder
```

This will return all property bag values for the folder MyFolder which is located in the root of the current web

### EXAMPLE 4
```powershell
Get-PnPPropertyBag -Folder /MyFolder -Key vti_mykey
```

This will return the value of the key vti_mykey from the folder MyFolder which is located in the root of the current web

### EXAMPLE 5
```powershell
Get-PnPPropertyBag -Folder / -Key vti_mykey
```

This will return the value of the key vti_mykey from the root folder of the current web

## PARAMETERS

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

### -Folder
Site relative url of the folder. See examples for use.

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Key
Key that should be looked up

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)