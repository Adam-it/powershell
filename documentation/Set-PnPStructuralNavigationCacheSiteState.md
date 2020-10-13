---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/set-pnpstructuralnavigationcachesitestate
schema: 2.0.0
title: Set-PnPStructuralNavigationCacheSiteState
---

# Set-PnPStructuralNavigationCacheSiteState

## SYNOPSIS
Enable or disable caching for all webs in a site collection.

## SYNTAX

```
Set-PnPStructuralNavigationCacheSiteState -IsEnabled <Boolean> [-SiteUrl <String>]
```

## DESCRIPTION
The Set-PnPStructuralNavigationCacheSiteState cmdlet can be used to enable or disable caching for all webs in a site collection. If the SiteUrl parameter has not been specified the currently connected to site will be used. [Learn more](https://support.office.com/article/structural-navigation-and-performance-f163053f-8eca-4b9c-b973-36b395093b43). 

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-PnPStructuralNavigationCacheSiteState -IsEnabled $true -SiteUrl "https://contoso.sharepoint.com/sites/product/" 
```

This example enables caching for all webs in the site collection https://contoso.sharepoint.com/sites/product/.

### Example 1
```powershell
PS C:\> Set-PnPStructuralNavigationCacheSiteState -IsEnabled $false -SiteUrl "https://contoso.sharepoint.com/sites/product/" 
```

This example disabled caching for all webs in the site collection https://contoso.sharepoint.com/sites/product/.

## PARAMETERS

### -IsEnabled
$true to enable caching, $false to disable caching.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:
Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteUrl
Specifies the absolute URL for the site collection's root web that needs its caching state to be set.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](https://aka.ms/sppnp)