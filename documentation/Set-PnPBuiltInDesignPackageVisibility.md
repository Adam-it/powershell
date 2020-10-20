---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/set-pnpbuiltindesignpackagevisibility
schema: 2.0.0
title: Set-PnPBuiltInDesignPackageVisibility
---

# Get-PnPBuiltInDesignPackageVisibility

## SYNOPSIS
Sets the visibility of the available built-in Design Packages at moment of site creation.

## SYNTAX

```powershell
Set-PnPBuiltInDesignPackageVisibility [-IsVisible] <Boolean> [-DesignPackage] <DesignPackageType>
 [<CommonParameters>]
```

## DESCRIPTION
Sets the visibility of the available built-in Design Packages.

## EXAMPLES

### EXAMPLE 1
```powershell
Set-PnPBuiltInDesignPackageVisibility -DesignPackage Showcase -IsVisible:$false
```

This example sets the visibility state of Showcase built-in design package to false.

### EXAMPLE 2
```powershell
Set-PnPBuiltInDesignPackageVisibility -DesignPackage TeamSite -IsVisible:$true
```

This example sets the visibility of TeamSite design package to true.

## PARAMETERS

### -DesignPackage
Name of the design package, available names are

* Topic
* Showcase
* Blank
* TeamSite

```yaml
Type: DesignPackageType
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsVisbible
Name of the design package, available names are

```yaml
Type: Boolean
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)