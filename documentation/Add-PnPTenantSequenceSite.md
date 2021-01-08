---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://pnp.github.io/powershell/cmdlets/add-pnptenantsequencesite
schema: 2.0.0
title: Add-PnPTenantSequenceSite
---

# Add-PnPTenantSequenceSite

## SYNOPSIS
Adds a existing tenant sequence site object to a tenant template

## SYNTAX

```powershell
Add-PnPTenantSequenceSite -Site <ProvisioningSitePipeBind> -Sequence <ProvisioningSequence> 
  [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Add-PnPTenantSequenceSite -Site $myteamsite -Sequence $mysequence
```

Adds an existing site object to an existing template sequence

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

### -Sequence
The sequence to add the site to

```yaml
Type: ProvisioningSequence
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Site

```yaml
Type: ProvisioningSitePipeBind
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)