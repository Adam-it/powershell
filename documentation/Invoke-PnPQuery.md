---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://pnp.github.io/powershell/cmdlets/invoke-pnpquery
schema: 2.0.0
title: Invoke-PnPQuery
---

# Invoke-PnPQuery

## SYNOPSIS
Executes the currently queued actions

## SYNTAX

```powershell
Invoke-PnPQuery [-RetryCount <Int32>] [-RetryWait <Int32>] [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION
Executes any queued actions / changes on the SharePoint Client Side Object Model Context

## EXAMPLES

### EXAMPLE 1
```powershell
Invoke-PnPQuery -RetryCount 5
```

This will execute any queued actions / changes on the SharePoint Client Side Object Model Context and will retry 5 times in case of throttling.

### EXAMPLE 2
```powershell
Invoke-PnPQuery -RetryWait 10
```

This will execute any queued actions / changes on the SharePoint Client Side Object Model Context and delay the execution for 10 seconds before it retries the execution.

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

### -RetryCount
Number of times to retry in case of throttling. Defaults to 10.

```yaml
Type: Int32
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryWait
Delay in seconds. Defaults to 1.

```yaml
Type: Int32
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)