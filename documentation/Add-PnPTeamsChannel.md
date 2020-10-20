---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/add-pnpteamschannel
schema: 2.0.0
title: Add-PnPTeamsChannel
---

# Add-PnPTeamsChannel

## SYNOPSIS

**Required Permissions**

  * Microsoft Graph API: Group.ReadWrite.All

Adds a channel to an existing Microsoft Teams instance.

## SYNTAX

### Public channel
```powershell
Add-PnPTeamsChannel -Team <TeamsTeamPipeBind> -DisplayName <String> [-Description <String>] [<CommonParameters>]
```

### Private channel
```powershell
Add-PnPTeamsChannel -Team <TeamsTeamPipeBind> -DisplayName <String> -OwnerUPN <String> [-Description <String>] [-Private] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Add-PnPTeamsChannel -Team 4efdf392-8225-4763-9e7f-4edeb7f721aa -DisplayName "My Channel"
```

Adds a new channel to the specified Teams instance

### EXAMPLE 2
```powershell
Add-PnPTeamsChannel -Team MyTeam -DisplayName "My Channel"
```

Adds a new channel to the specified Teams instance

### EXAMPLE 3
```powershell
Add-PnPTeamsChannel -Team MyTeam -DisplayName "My Channel" -Private -OwnerUPN user1@domain.com
```

Adds a new private channel to the specified Teams instance

## PARAMETERS

### -Description
An optional description of the channel.

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name of the new channel. Letters, numbers and spaces are allowed.

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OwnerUPN
The User Principal Name (email) of the owner of the channel.

```yaml
Type: String
Parameter Sets: Private channel

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Private
Specify to mark the channel as private.

```yaml
Type: SwitchParameter
Parameter Sets: Private channel

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Team
Specify the group id, mailNickname or display name of the team to use.

```yaml
Type: TeamsTeamPipeBind
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)
