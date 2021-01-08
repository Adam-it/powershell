---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://pnp.github.io/powershell/cmdlets/get-pnppowershelltelemetryenabled
schema: 2.0.0
title: Get-PnPPowerShellTelemetryEnabled
---

# Get-PnPPowerShellTelemetryEnabled

## SYNOPSIS
Returns true if the PnP PowerShell Telemetry has been enabled.

## SYNTAX

```powershell
Get-PnPPowerShellTelemetryEnabled [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION
In order to help to make PnP PowerShell better, we can track anonymous telemetry. We track the version of the cmdlets you are using, which cmdlet you are executing and which version of SharePoint you are connecting to. Use Disable-PnPPowerShellTelemetry to turn this off, alternative, use the -NoTelemetry switch on Connect-PnPOnline to turn it off for that session.

## EXAMPLES

### EXAMPLE 1
```powershell
Get-PnPPowerShellTelemetryEnabled
```

Will return true of false.

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

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)