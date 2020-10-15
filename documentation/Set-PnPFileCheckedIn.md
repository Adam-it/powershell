---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/set-pnpfilecheckedin
schema: 2.0.0
title: Set-PnPFileCheckedIn
---

# Set-PnPFileCheckedIn

## SYNOPSIS
Checks in a file

## SYNTAX

```powershell
Set-PnPFileCheckedIn [-Url] <String> [-CheckinType <CheckinType>] [-Comment <String>] [-Approve]
 [-Web <WebPipeBind>] [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
PS:>Set-PnPFileCheckedIn -Url "/Documents/Contract.docx"
```

Checks in the file "Contract.docx" in the "Documents" library

### EXAMPLE 2
```powershell
PS:>Set-PnPFileCheckedIn -Url "/Documents/Contract.docx" -CheckinType MinorCheckin -Comment "Smaller changes"
```

Checks in the file "Contract.docx" in the "Documents" library as a minor version and adds the check in comment "Smaller changes"

## PARAMETERS

### -Approve
Approve file

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CheckinType
The check in type to use. Defaults to Major

```yaml
Type: CheckinType
Parameter Sets: (All)
Accepted values: MinorCheckIn, MajorCheckIn, OverwriteCheckIn

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Comment
The check in comment

```yaml
Type: String
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

### -Url
The server relative url of the file to check in

```yaml
Type: String
Parameter Sets: (All)

Required: True
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