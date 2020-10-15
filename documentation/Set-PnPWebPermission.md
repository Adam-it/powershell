---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name:
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/set-pnpwebpermission
schema: 2.0.0
title: Set-PnPWebPermission
---

# Set-PnPWebPartProperty

## SYNOPSIS
Sets a web part property

## SYNTAX

```powershell
Set-PnPWebPartProperty -ServerRelativePageUrl <String> -Identity <Guid> -Key <String> -Value <PSObject>
 [-Web <WebPipeBind>] [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Set-PnPWebPartProperty -ServerRelativePageUrl /sites/demo/sitepages/home.aspx -Identity ccd2c98a-c9ae-483b-ae72-19992d583914 -Key "Title" -Value "New Title"
```

Sets the title property of the web part.

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

### -Identity
The Guid of the web part

```yaml
Type: Guid
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Key
Name of a single property to be set

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerRelativePageUrl
Full server relative url of the web part page, e.g. /sites/demo/sitepages/home.aspx

```yaml
Type: String
Parameter Sets: (All)
Aliases: PageUrl

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Value of the property to be set

```yaml
Type: PSObject
Parameter Sets: (All)

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