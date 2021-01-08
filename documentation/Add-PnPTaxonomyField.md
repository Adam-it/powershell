---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://pnp.github.io/powershell/cmdlets/add-pnptaxonomyfield
schema: 2.0.0
title: Add-PnPTaxonomyField
---

# Add-PnPTaxonomyField

## SYNOPSIS
Add a taxonomy field

## SYNTAX

### Path
```powershell
Add-PnPTaxonomyField [-List <ListPipeBind>] -DisplayName <String> -InternalName <String> -TermSetPath <String>
 [-TermPathDelimiter <String>] [-Group <String>] [-Id <Guid>] [-AddToDefaultView] [-MultiValue]
 [-Required] [-FieldOptions <AddFieldOptions>] [-Web <WebPipeBind>] [-Connection <PnPConnection>]
 [<CommonParameters>]
```

### Id
```powershell
Add-PnPTaxonomyField [-List <ListPipeBind>] -DisplayName <String> -InternalName <String>
 [-TaxonomyItemId <Guid>] [-Group <String>] [-Id <Guid>] [-AddToDefaultView] [-MultiValue]
 [-Required] [-FieldOptions <AddFieldOptions>] [-Web <WebPipeBind>] [-Connection <PnPConnection>]
 [<CommonParameters>]
```

## DESCRIPTION
Adds a taxonomy/managed metadata field to a list or as a site column.

## EXAMPLES

### EXAMPLE 1
```powershell
Add-PnPTaxonomyField -DisplayName "Test" -InternalName "Test" -TermSetPath "TestTermGroup|TestTermSet"
```

Adds a new taxonomy field called "Test" that points to the TestTermSet which is located in the TestTermGroup

## PARAMETERS

### -AddToDefaultView
Switch Parameter if this field must be added to the default view

```yaml
Type: SwitchParameter
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

### -DisplayName
The display name of the field

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FieldOptions
Specifies the control settings while adding a field. See https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.addfieldoptions.aspx for details

```yaml
Type: AddFieldOptions
Parameter Sets: (All)
Accepted values: DefaultValue, AddToDefaultContentType, AddToNoContentType, AddToAllContentTypes, AddFieldInternalNameHint, AddFieldToDefaultView, AddFieldCheckDisplayName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group
The group name to where this field belongs to

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The ID for the field, must be unique

```yaml
Type: Guid
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InternalName
The internal name of the field

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -List
The list object or name where this field needs to be added

```yaml
Type: ListPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MultiValue
Switch Parameter if this Taxonomy field can hold multiple values

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Required
Switch Parameter if the field is a required field

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaxonomyItemId
The ID of the Taxonomy item

```yaml
Type: Guid
Parameter Sets: Id

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermPathDelimiter
The path delimiter to be used, by default this is '|'

```yaml
Type: String
Parameter Sets: Path

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TermSetPath
The path to the term that this needs to be bound

```yaml
Type: String
Parameter Sets: Path

Required: True
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

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)