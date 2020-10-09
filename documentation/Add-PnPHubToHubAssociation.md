---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/add-pnphubtohubassociation
schema: 2.0.0
title: Add-PnPHubToHubAssociation
---

# Add-PnPHubToHubAssociation

## SYNOPSIS

**Required Permissions**

* SharePoint: Access to the SharePoint Tenant Administration site

Associates a hub site to a hub site.

## SYNTAX

### By Id

```powershell
Add-PnPHubToHubAssociation -Source <Guid> -Target <Guid> [-Connection <PnPConnection>]
```

### By Url

```powershell
Add-PnPHubToHubAssociation -SourceUrl <string> -TargetUrl <string> [-Connection <PnPConnection>]
```

## DESCRIPTION
Use this cmdlet to associate a hub site to a hub site.

## EXAMPLES

### EXAMPLE 1
```powershell
Add-PnPHubToHubAssociation -Source 6638bd4c-d88d-447c-9eb2-c84f28ba8b15 -Target 0b70f9de-2b98-46e9-862f-ba5700aa2443
```

This example associates the source hub site with the HubSiteId 6638bd4c-d88d-447c-9eb2-c84f28ba8b15 with the target hub site with the HubSiteId 0b70f9de-2b98-46e9-862f-ba5700aa2443.

### EXAMPLE 2
```powershell
Add-PnPHubToHubAssociation -SourceUrl https://yourtenant.sharepoint.com/sites/sourcehub -TargetUrl https://yourtenant.sharepoint.com/sites/targethub
```

This example associates the source hub site with the url https://yourtenant.sharepoint.com/sites/sourcehub with the target hub site with the url https://yourtenant.sharepoint.com/sites/targethub.

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

### -Source
HubSiteId of the Source Hub site to be associated with the Target Hub Site.

```yaml
Type: Guid
Parameter Sets: By Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target
HubSiteId of the Target Hub to associate the source Hub to.

```yaml
Type: Guid
Parameter Sets: By Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceUrl
URL of the Source Hub site to be associated with the Target Hub Site.

```yaml
Type: Guid
Parameter Sets: By Url

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target
URL of the Target Hub to associate the source Hub to.

```yaml
Type: Guid
Parameter Sets: By Url

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](https://aka.ms/sppnp)
