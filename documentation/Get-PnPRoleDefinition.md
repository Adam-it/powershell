---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://pnp.github.io/powershell/cmdlets/get-pnproledefinition
schema: 2.0.0
title: Get-PnPRoleDefinition
---

# Get-PnPRoleDefinition

## SYNOPSIS
Retrieves a Role Definitions of a site

## SYNTAX

```powershell
Get-PnPRoleDefinition [[-Identity] <RoleDefinitionPipeBind>] [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Get-PnPRoleDefinition
```

Retrieves the Role Definitions (Permission Levels) settings of the current site

### EXAMPLE 2
```powershell
Get-PnPRoleDefinition -Identity Read
```

Retrieves the specified Role Definition (Permission Level) settings of the current site

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
The name of a role definition to retrieve.

```yaml
Type: RoleDefinitionPipeBind
Parameter Sets: (All)

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)