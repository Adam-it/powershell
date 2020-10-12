---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/remove-pnptenantsyncclientrestriction
schema: 2.0.0
title: Remove-PnPTenantSyncClientRestriction
---

# Remove-PnPTenantSyncClientRestriction

## SYNOPSIS

**Required Permissions**

* SharePoint: Access to the SharePoint Tenant Administration site

Returns organization-level OneDrive synchronization restriction settings

## SYNTAX

```powershell
Remove-PnPTenantSyncClientRestriction
```

## DESCRIPTION
The Remove-PnPTenantSyncClientRestriction cmdlet disables the feature for the tenant, but does not remove any present domain GUID entries from the safe sender recipient list. After the Remove-PnPTenantSyncClientRestriction cmdlet is run it can take up to 24 hours for change to take effect. This parameter will also remove any values set from the GrooveBlockOption parameter for syncing.

## EXAMPLES

### EXAMPLE 1
```powershell
Remove-PnPTenantSyncClientRestriction
```

This example disables this feature for the tenant.

## RELATED LINKS

[SharePoint Developer Patterns and Practices](https://aka.ms/sppnp)