---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/add-pnpclientsidepage
schema: 2.0.0
title: Add-PnPClientSidePage
---

# Add-PnPClientSidePage

## SYNOPSIS
Adds a Client-Side Page

## SYNTAX

```powershell
Add-PnPClientSidePage [-Name] <String> [-LayoutType <ClientSidePageLayoutType>]
 [-PromoteAs <ClientSidePagePromoteType>] [-ContentType <ContentTypePipeBind>] [-CommentsEnabled] [-Publish]
 [-HeaderLayoutType <ClientSidePageHeaderLayoutType>] [-Web <WebPipeBind>] [-Connection <PnPConnection>]
 [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Add-PnPClientSidePage -Name "NewPage"
```

Creates a new Client-Side page named 'NewPage'

### EXAMPLE 2
```powershell
Add-PnPClientSidePage -Name "NewPage" -ContentType "MyPageContentType"
```

Creates a new Client-Side page named 'NewPage' and sets the content type to the content type specified

### EXAMPLE 3
```powershell
Add-PnPClientSidePage -Name "NewPageTemplate" -PromoteAs Template
```

Creates a new Client-Side page named 'NewPage' and saves as a template to the site.

### EXAMPLE 4
```powershell
Add-PnPClientSidePage -Name "Folder/NewPage"
```

Creates a new Client-Side page named 'NewPage' under 'Folder' folder and saves as a template to the site.

### EXAMPLE 5
```powershell
Add-PnPClientSidePage -Name "NewPage" -HeaderLayoutType ColorBlock
```

Creates a new Client-Side page named 'NewPage' using the ColorBlock header layout

## PARAMETERS

### -CommentsEnabled
Enables or Disables the comments on the page

```yaml
Type: SwitchParameter
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

### -ContentType
Specify either the name, ID or an actual content type.

```yaml
Type: ContentTypePipeBind
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HeaderLayoutType
Type of layout used for the header

```yaml
Type: ClientSidePageHeaderLayoutType
Parameter Sets: (All)
Accepted values: FullWidthImage, NoImage, ColorBlock, CutInShape

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LayoutType
Specifies the layout type of the page.

```yaml
Type: ClientSidePageLayoutType
Parameter Sets: (All)
Accepted values: Article, Home, SingleWebPartAppPage, RepostPage, HeaderlessSearchResults, Spaces, Topic

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the page.

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PromoteAs
Allows to promote the page for a specific purpose (HomePage | NewsPage)

```yaml
Type: ClientSidePagePromoteType
Parameter Sets: (All)
Accepted values: None, HomePage, NewsArticle, Template

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publish
Publishes the page once it is saved. Applicable to libraries set to create major and minor versions.

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

[SharePoint Developer Patterns and Practices](https://aka.ms/sppnp)