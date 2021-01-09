---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://pnp.github.io/powershell/cmdlets/add-pnpcontenttypetolist
schema: 2.0.0
title: Add-PnPContentTypeToList
---

# Add-PnPContentTypeToList

## SYNOPSIS
Adds a new content type to a list

## SYNTAX

```powershell
Add-PnPContentTypeToList -List <ListPipeBind> -ContentType <ContentTypePipeBind> [-DefaultContentType]
 [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Add-PnPContentTypeToList -List "Documents" -ContentType "Project Document" -DefaultContentType
```

This will add an existing content type to a list and sets it as the default content type

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

### -ContentType
Specifies the content type that needs to be added to the list

```yaml
Type: ContentTypePipeBind
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultContentType
Specify if the content type needs to be the default content type or not

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
Specifies the list to which the content type needs to be added

```yaml
Type: ListPipeBind
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```



## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)